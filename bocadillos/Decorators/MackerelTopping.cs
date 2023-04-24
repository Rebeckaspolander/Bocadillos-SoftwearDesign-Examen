using bocadillos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocadillos.Decorators
{
	public class MackerelTopping : ToppingDecorator
	{
		public MackerelTopping(Sandwich baseSandwich) : base(baseSandwich)
		{
		}

		public override string GetDescription()
		{
			return base.GetDescription() + ToppingDAO.GetToppingDescription("Mackerel") + "\n";
		}

		public override int GetPrice()
		{
			return base.GetPrice() + ToppingDAO.GetToppingPrice("Mackerel");
		}
	}
}
