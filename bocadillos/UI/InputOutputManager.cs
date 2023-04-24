using bocadillos.Bases;
using bocadillos.Bases.Customer;
using bocadillos.Bases.Product;
using bocadillos.Components;
using bocadillos.Controllers;
using bocadillos.Decorators;
using System;
using System.Diagnostics.Metrics;

namespace bocadillos.UI
{
    public class InputOutputManager
    {
		private static int _counter = 0;
        private readonly PlainWheatSandwich _plainWheatSandwich = new();
        private readonly RyeBreadSandwich _ryeBreadSandwich = new();
        private readonly SourdoughSandwich _sourdoughSandwich = new();

        private Customer? _customer;

        public void Run()
        {
			Console.WriteLine("Please register before ordering");
			_customer = GetCustomer();

			if(_customer.FirstName.ToLower() == "tomas")
			{
				Console.WriteLine("Congratulations, since your name is Tomas without an 'H' you get a free beer on the house!\n");
			}

			if(_customer.FirstName == "" || _customer.LastName == "")
			{
				Console.WriteLine("Please enter a valid name");
				_customer = GetCustomer();
			}

            Console.WriteLine($"Welcome to Bocadillos, {_customer.FirstName}. What would you like to do today?");
            Console.WriteLine("1- Order a sandwich \n0- Nothing goodbye!");
            
			string? input = Console.ReadLine();

			Console.Clear();

			switch (input)
			{
				case "1":
					Console.WriteLine("You chose to order a sandwich\n");
						CreateSandwich();
					break;
				case "0":
					Console.WriteLine("Thank you, goodbye :-)");
					Console.ReadKey();
					break;
				default: 
                    Console.WriteLine("You chose nothing. Thank you, goodbye! :-)");
                    Console.ReadKey();
                    break;
            }
		}

		private void PrintSandwich(Sandwich sandwich)
		{
			SandwichDAO.InsertIntoSandwich(sandwich);

			if (_customer != null)
			{
				OrderDAO.InsertIntoOrder(sandwich, _customer);
				var completedSandwich = OrderDAO.GetOrderedSandwich(_customer);

				Console.WriteLine($"You order is finished and will be delivered to {_customer.Address}, please enjoy your sandwich\n");
				Thread.Sleep(500);
				Console.WriteLine($"{completedSandwich.Description}");
				Thread.Sleep(500);
				Console.WriteLine($"New price for sandwich: {completedSandwich.Price} NOK");
				Thread.Sleep(500);

				if(_customer.FirstName.ToLower() == "tomas")
				{
					Console.WriteLine("And don't forget your cold and refreshing beer on the house! :)\n");
				}
				Console.WriteLine($"Thank you {_customer.FirstName}, and please come again!");
			}
			else
			{
				Console.WriteLine("It seems there was an error with the registration, please register again.");
				GetCustomer();
			}
		}

        private void CreateSandwich()
        {
            Console.WriteLine("Please choose what kind of bread you want");
            Console.WriteLine($"1 - {_plainWheatSandwich.Name}");
            Console.WriteLine($"2 - {_ryeBreadSandwich.Name}");
            Console.WriteLine($"3 - {_sourdoughSandwich.Name}");
            Console.WriteLine("0 - Nothing, goodbye!");

            string? input = Console.ReadLine();

            Console.Clear();

            switch (input)
            {
                case "1":
                    CreateWheatSandwich(_plainWheatSandwich);
                    break;
                case "2":
                    CreateRyeSandwich(_ryeBreadSandwich);
                    break;
                case "3":
                    CreateSourdoughSandwich(_sourdoughSandwich);
                    break;
                case "0":
                    Console.WriteLine($"Thank you, goodbye {_customer.FirstName}! :-)");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Please choose an item from the list.");
                    Thread.Sleep(1100);
                    break;
            }
        }

        private void CreateWheatSandwich(PlainWheatSandwich plainWheatSandwich)
        {
            Sandwich sandwich = plainWheatSandwich;
            CreateTopping(sandwich);
        }

        private void CreateRyeSandwich(RyeBreadSandwich ryeBreadSandwich)
        {
            Sandwich sandwich = ryeBreadSandwich;
            CreateTopping(sandwich);
        }

        private void CreateSourdoughSandwich(SourdoughSandwich sourdoughSandwich)
        {
            Sandwich sandwich = sourdoughSandwich;
            CreateTopping(sandwich);
        }

        private void CreateTopping(Sandwich sandwich)
		{
			CreateOwnSandwich(sandwich);
		}

		private void CreateOwnSandwich(Sandwich sandwich)
		{
            Console.WriteLine(sandwich.ToString());
            Console.WriteLine("You can choose 5 toppings for your sandwich - choose wisely...!");

            while (_counter != 5)
            {
				ShowToppingMenu();

                Console.WriteLine($"You have chosen: {_counter}/5 toppings");

                string? input = Console.ReadLine();

                switch (input)
				{
					case "1":
						sandwich = new ArugulaTopping(sandwich);
						//AddTopping(input, sandwich);
						_counter++;
						Console.Clear();
						break;
					case "2":
						sandwich = new BeefTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "3":
						sandwich = new BellPepperTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "4":
						sandwich = new ButterTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "5":
						sandwich = new CheeseTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "6":
						sandwich = new ChickenTeryakiTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "7":
						sandwich = new FermentedHerringTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "8":
						sandwich = new GuacamoleTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "9":
						sandwich = new HamTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "10":
						sandwich = new JalapenoTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "11":
						sandwich = new KimchiTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "12":
						sandwich = new MackerelTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "13":
						sandwich = new MozzarellaTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "14":
						sandwich = new OnionTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "15":
						sandwich = new PlacentaTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "16":
						sandwich = new RoadKillTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "17":
						sandwich = new SaladTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "18":
						sandwich = new ShrimpCabaretTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "19":
						sandwich = new TomatoTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "20":
						sandwich = new TurkeyTopping(sandwich);
						_counter++;
						Console.Clear();
						break;
					case "0":
						_counter++;
						Console.Clear();
						break;
                    default:
                        Console.WriteLine("Please choose an item from the list.");
                        Thread.Sleep(1100);
                        break;
                }
			}
			PrintSandwich(sandwich);
		}

		private static void ShowToppingMenu()
		{
			var toppings = ToppingDAO.GetToppings();

			for (int i = 0; i < toppings.Count; i++)
			{
				Console.WriteLine(toppings[i].ToString());
			}

			Console.WriteLine("0 - No topping");
		}

		public static Customer GetCustomer()
        {
			Console.WriteLine("Your name");
			string? firstName = Console.ReadLine();

			Console.WriteLine("Your lastname");
            string? lastName = Console.ReadLine();

			Console.WriteLine("Your address");
            string? address = Console.ReadLine();

			Console.WriteLine("Your email");
            string? email = Console.ReadLine();

			Console.WriteLine("Your phone number");
            string? phone = Console.ReadLine();

			Customer customer = new(firstName, lastName, address, email, phone);

			CustomerDAO.InsertIntoCustomers(customer);

			Console.Clear();

			return customer;

        }
    }
}

