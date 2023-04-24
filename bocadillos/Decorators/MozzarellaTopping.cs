using bocadillos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocadillos.Decorators
{
	public class MozzarellaTopping : ToppingDecorator
	{
		public MozzarellaTopping(Sandwich baseSandwich) : base(baseSandwich)
		{
		}

		public override string GetDescription()
		{
			return base.GetDescription() + ToppingDAO.GetToppingDescription("Mozzarella") + "\n";
		}

		public override int GetPrice()
		{
			return base.GetPrice() + ToppingDAO.GetToppingPrice("Mozzarella");
		}
	}
}
