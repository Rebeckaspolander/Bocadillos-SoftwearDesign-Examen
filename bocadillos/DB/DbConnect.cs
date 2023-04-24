using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using bocadillos.Bases.Customer;
using Microsoft.Data.Sqlite;

namespace bocadillos.DB
{
	public class DbConnect
	{
		public static void CreateDb()
		{
			CreateToppingTable();
			CreateCustomerTable();
			CreateSandwichTable();	
			CreateOrderTable();
		}

		public static void CreateToppingTable()
		{
			SqliteConnection connection = SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				CREATE TABLE IF NOT EXISTS topping (
					id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
					name TEXT NOT NULL,
					description TEXT NOT NULL,
					price INTEGER NOT NULL
				);
			";
			statement.ExecuteNonQuery();
		}

		public static void CreateCustomerTable()
		{
			SqliteConnection connection = SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				CREATE TABLE IF NOT EXISTS customer (
					id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
					first_name TEXT NOT NULL,
					last_name TEXT NOT NULL,
					address TEXT NOT NULL,
					phone_number TEXT NOT NULL,
					email TEXT NOT NULL
				);
			";
			statement.ExecuteNonQuery();
		}

		public static void CreateSandwichTable()
		{
			SqliteConnection connection = SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				CREATE TABLE IF NOT EXISTS sandwich (
					id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
					description TEXT NOT NULL,
					price INTEGER NOT NULL
				);
			";
			statement.ExecuteNonQuery();
		}

		public static void CreateOrderTable()
		{
			SqliteConnection connection = SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				CREATE TABLE IF NOT EXISTS customer_sandwich_order (
					customer_id INTEGER NOT NULL,
					sandwich_id INTEGER NOT NULL,
                    FOREIGN KEY (customer_id) REFERENCES customer(id),
                    FOREIGN KEY (sandwich_id) REFERENCES sandwich(id),
					PRIMARY KEY(customer_id, sandwich_id)
                );
            ";
            statement.ExecuteNonQuery();
		}

		public static SqliteConnection SetUpConnection()
		{
			SqliteConnection connection = new("Data Source = bocadillos.db");
			connection.Open();
			return connection;
		}

		public static void DropDataBase()
		{
			File.Delete("bocadillos.db");
		}
	}
}
