using bocadillos.DB;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bocadillos.Controllers
{
	public class SandwichDAO
	{
		public static void InsertIntoSandwich(Sandwich sandwich)
		{
			SqliteConnection connection = DbConnect.SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				INSERT INTO sandwich (description, price)
				VALUES ($description, $price)
			";

			statement.Parameters.AddWithValue("$description", sandwich.GetDescription());
			statement.Parameters.AddWithValue("$price", sandwich.GetPrice());
			statement.ExecuteNonQuery();
		}
	}
}
