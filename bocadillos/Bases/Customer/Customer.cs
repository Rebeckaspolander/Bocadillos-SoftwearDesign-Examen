using System;
namespace bocadillos.Bases.Customer
{
	public class Customer
	{
		public int Id { get; set; }
		public string? FirstName { get; }
		public string? LastName { get; }
		public string? Address { get; }
		public string? PhoneNumber { get; }
		public string? Email { get; }

		public Customer(string firstName, string lastName, string adress, string phoneNumber, string email)
		{
			FirstName = firstName;
			LastName = lastName;
			Address = adress;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		public void GetCustomer(string firstName, string lastName, string address, string phoneNumber, string email)
		{
			Customer customer = new(firstName, lastName, address, phoneNumber, email);

            if (firstName == "" || firstName == null)
            {
                Console.WriteLine("Please enter your name.");
            }
        }
	}
}

