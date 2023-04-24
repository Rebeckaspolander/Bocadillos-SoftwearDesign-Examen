using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocadillos.Bases.Product
{
	public class ToppingDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; } 
		public int Price { get; set; }

		public ToppingDTO(string name, string description, int price)
		{
			Name = name;
			Description = description;
			Price = price;
		}
	}
}
