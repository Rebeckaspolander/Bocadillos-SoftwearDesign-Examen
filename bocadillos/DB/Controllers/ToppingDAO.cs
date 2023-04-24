using System;
using System.Collections;
using bocadillos.DB;
using bocadillos.Decorators;
using bocadillos.Bases;
using System.Text.Json.Nodes;
using Microsoft.Data.Sqlite;
using System.Text;
using bocadillos.Bases.Product;

namespace bocadillos.Controllers
{
	public class ToppingDAO
	{

        public static void AddToppingsToDatabase()
		{
			ArrayList toppings = new();

            toppings.Add(new ToppingDTO("Arugula", "Some arugula", 2));
            toppings.Add(new ToppingDTO("Beef", "Some beefy beef", 12));
            toppings.Add(new ToppingDTO("Bell pepper", "Bell peppers", 6));
            toppings.Add(new ToppingDTO("Butter", "Butter", 2));
            toppings.Add(new ToppingDTO("Cheese", "Some mellow-yellow cheese", 8));
            toppings.Add(new ToppingDTO("Chicken teryaki", "Chicken breast matinated in teryaki sauce", 10));
            toppings.Add(new ToppingDTO("Fermented herring", "Some refreshing fermented herring", 25));
            toppings.Add(new ToppingDTO("Guacamole", "A chunky, funky guacamole", 20));
            toppings.Add(new ToppingDTO("Ham", "A slice of ham (from a pig)", 10));
            toppings.Add(new ToppingDTO("Jalapeno", "A slice of ham (from a pig)", 9));
            toppings.Add(new ToppingDTO("Kimchi", "Spicy, pricy kimchi", 14));
            toppings.Add(new ToppingDTO("Mackerel", "Mackerel in tomato sauce", 8));
            toppings.Add(new ToppingDTO("Mozarella", "Some Mozzarella", 12));
            toppings.Add(new ToppingDTO("Onion", "Some stingy onion", 3));
            toppings.Add(new ToppingDTO("Placenta", "Some exquisite and devilish good sundried goat placenta, imported by donkey- from the mountains of Guatemala <3", 666));
            toppings.Add(new ToppingDTO("Road kill", "Todays freshly gathered Road Kill, on the house!", 0));
            toppings.Add(new ToppingDTO("Salad", "Green mean salad (from a machine)", 4));
            toppings.Add(new ToppingDTO("Shrimp cabaret", "Some lovely shrimp cabaret, made by my grandma", 15));
            toppings.Add(new ToppingDTO("Tomato", "Tomato", 7));
            toppings.Add(new ToppingDTO("Turkey", "A slice of creamy turkey", 10));

            foreach(ToppingDTO t in toppings)
            {
				InsertIntoTopping(t);
            }
        }

		public static void InsertIntoTopping(ToppingDTO topping)
		{
			SqliteConnection connection = DbConnect.SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				INSERT OR IGNORE INTO topping (name, description, price)
				VALUES ($name, $description, $price)
			";

			statement.Parameters.AddWithValue("$name", topping.Name);
			statement.Parameters.AddWithValue("$description", topping.Description);
			statement.Parameters.AddWithValue("$price", topping.Price);

			statement.ExecuteNonQuery();
		}

		public static List<string> GetToppings()
		{
			string toppingId = "";
			string toppingName = "";

			SqliteConnection connection = DbConnect.SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				SELECT id, name 
				FROM topping
			";

			statement.ExecuteNonQuery();

			using SqliteDataReader reader = statement.ExecuteReader();

			var toppings = new List<string>();

			while (reader.Read())
			{
				toppingId = reader.GetInt32(0).ToString();
				toppingName = reader.GetString(1);

				var topping = CreateTopping(toppingId, toppingName);

				toppings.Add(topping);
			}

			return toppings;
		}

		public static string CreateTopping(string toppingId, string toppingName)
		{
			StringBuilder sb = new();
			sb.Append(toppingId).Append(" - ").Append(toppingName);
			return sb.ToString();
		}

		public static string GetToppingDescription(string toppingName)
		{
			string toppingDescription = "";

			SqliteConnection connection = DbConnect.SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				SELECT description
				FROM topping
				WHERE name = $name
			";

			statement.Parameters.AddWithValue("$name", toppingName);
			statement.ExecuteNonQuery();

			using SqliteDataReader reader = statement.ExecuteReader();
			if (reader.Read())
			{
				toppingDescription = reader.GetString(0);
			}
			return toppingDescription;
		}

		public static int GetToppingPrice(string toppingName)
		{
			int toppingPrice = 0;

			SqliteConnection connection = DbConnect.SetUpConnection();
			SqliteCommand statement = connection.CreateCommand();

			statement.CommandText = @"
				SELECT price
				FROM topping
				WHERE name = $name
			";

			statement.Parameters.AddWithValue("$name", toppingName);
			statement.ExecuteNonQuery();

			using SqliteDataReader reader = statement.ExecuteReader();
			if (reader.Read())
			{
				toppingPrice = reader.GetInt32(0);
			}
			return toppingPrice;
		}
	}
}

