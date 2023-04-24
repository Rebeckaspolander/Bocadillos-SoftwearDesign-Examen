using System;
using System.Reflection.PortableExecutable;
using bocadillos;
using bocadillos.Bases.Customer;
using bocadillos.DB;
using bocadillos.Controllers;
using bocadillos.Decorators;
using Microsoft.Data.Sqlite;
using bocadillos.Bases;

namespace BocadillosTests
{
	public class DatabaseTest
	{
        [SetUp]
        public void Setup()
        {
            DbConnect.DropDataBase();
            DbConnect.CreateDb();
        }

        [Test]
        public void InsertAndGetCustomerFromDatabase()
        {
            CustomerDAO cc = new();
            Customer customer = new Customer("Test", "Persson", "testveien 1", "test@gmail.com", "12345678");

            CustomerDAO.InsertIntoCustomers(customer);

            var result = CustomerDAO.GetCustomer(customer.Id);

            Assert.That(result.ToString(), Is.EqualTo(customer.ToString()));
        }

        [Test]
        public void InsertAndGetOrderFromDatabase()
        {
            Customer customer = new Customer("Test", "Persson", "hejhejhej", "test@gmail.com", "12345678");

            CustomerDAO.InsertIntoCustomers(customer);

            Sandwich sandwich = new PlainWheatSandwich();
            CheeseTopping cheese = new CheeseTopping(sandwich);
            OnionTopping onion = new OnionTopping(sandwich);
            TomatoTopping tomato = new TomatoTopping(sandwich);
            PlacentaTopping placenta = new PlacentaTopping(sandwich);

            SandwichDAO.InsertIntoSandwich(sandwich);

            OrderDAO.InsertIntoOrder(sandwich, customer);

            var result = OrderDAO.GetOrderedSandwich(customer);

            Assert.That(result.Description, Is.EqualTo(sandwich.GetDescription()));
        }
    }

}

