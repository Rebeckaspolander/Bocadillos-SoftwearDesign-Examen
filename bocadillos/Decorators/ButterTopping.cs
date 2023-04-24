using bocadillos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocadillos.Decorators
{
	public class ButterTopping : ToppingDecorator
	{
		public ButterTopping(Sandwich baseSandwich) : base(baseSandwich)
		{
		}

		public override string GetDescription()
		{
			return base.GetDescription() + ToppingDAO.GetToppingDescription("Butter") + "\n";
		}

		public override int GetPrice()
		{
			return base.GetPrice() + ToppingDAO.GetToppingPrice("Butter");
		}
	}
}
