using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocadillos.Bases.Product
{
	public class SandwichDTO
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }

		public SandwichDTO(string description, int price)
		{
			Description = description;
			Price = price;
		}

		public SandwichDTO()
		{
		}
	}
}
