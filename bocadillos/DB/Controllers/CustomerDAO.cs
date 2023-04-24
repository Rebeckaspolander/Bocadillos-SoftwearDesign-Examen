using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bocadillos.DB;
using bocadillos.Bases.Customer;

namespace bocadillos.Controllers
{
	public class CustomerDAO
	{
		public static void InsertIntoCustomers(Customer customer)
		{
			SqliteConnection connection = DbConnect.SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				INSERT INTO customer (first_name, last_name, address, email, phone_number)
				VALUES ($firstName, $lastName, $address, $email, $phoneNumber);
			";

			statement.Parameters.AddWithValue("$firstName", customer.FirstName);
			statement.Parameters.AddWithValue("$lastName", customer.LastName);
			statement.Parameters.AddWithValue("$address", customer.Address);
			statement.Parameters.AddWithValue("$email", customer.Email);
			statement.Parameters.AddWithValue("$phoneNumber", customer.PhoneNumber);

			try
			{
                statement.ExecuteNonQuery();
            } catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

            statement.CommandText = "select last_insert_rowid()";

            Int64 LastRowID64 = (Int64)statement.ExecuteScalar();

			customer.Id = (int)LastRowID64;
        }

		public static Customer GetCustomer(int id)
		{
			SqliteConnection connection = DbConnect.SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				SELECT *
				FROM customer
				WHERE id = $id
			";

			statement.Parameters.AddWithValue("$id", id);
			statement.ExecuteNonQuery();


			using SqliteDataReader reader = statement.ExecuteReader();


            if (reader.Read())
			{
				Customer customer = new(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));

				return customer;
			}
			else
			{
				return null;
			}
	
		}
	}
}
