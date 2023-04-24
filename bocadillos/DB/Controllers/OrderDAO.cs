using bocadillos.Bases.Customer;
using bocadillos.Bases.Product;
using bocadillos.DB;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bocadillos.Controllers
{
	public class OrderDAO
	{
		public static void InsertIntoOrder(Sandwich sandwich, Customer customer)
		{
			SqliteConnection connection = DbConnect.SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();
			statement.CommandText = @"
				SELECT max(id)
				FROM customer
			";

            using SqliteDataReader reader = statement.ExecuteReader();

			while (reader.Read())
			{
				customer.Id = reader.GetInt32(0);
			}			

			reader.Close();

            statement.CommandText = @"
				SELECT max(id)
				FROM sandwich
			";

            using SqliteDataReader r = statement.ExecuteReader();

            while (r.Read())
            {
                sandwich.Id = r.GetInt32(0);
            }
			r.Close();

            statement.CommandText = @"
				INSERT INTO customer_sandwich_order (customer_id, sandwich_id)
				VALUES ($customer_id, $sandwich_id)
			";

			statement.Parameters.AddWithValue("$customer_id", customer.Id);
			statement.Parameters.AddWithValue("$sandwich_id", sandwich.Id);
			statement.ExecuteNonQuery();
        }

		public static SandwichDTO GetOrderedSandwich(Customer customer)
		{
			SqliteConnection connection = DbConnect.SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();
			statement.CommandText = @"
				SELECT s.*
				FROM customer_sandwich_order o JOIN sandwich s ON o.sandwich_id = s.id
				WHERE customer_id = $customer_id
			";

			statement.Parameters.AddWithValue("$customer_id", customer.Id);
			statement.ExecuteNonQuery();

			using SqliteDataReader reader = statement.ExecuteReader();

			var sandwich = new SandwichDTO();
			while (reader.Read())
			{
				sandwich.Description = reader.GetString(1);
				sandwich.Price = reader.GetInt32(2);
			}
			return sandwich;
		}
	}
}
