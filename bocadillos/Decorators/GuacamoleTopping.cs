using bocadillos.Bases;
using bocadillos.Controllers;
using System;
namespace bocadillos.Decorators
{
    public class GuacamoleTopping : ToppingDecorator
    {
		public GuacamoleTopping(Sandwich basesandwich) : base(basesandwich)
        {
        }

		public override string GetDescription()
		{
			return base.GetDescription() + ToppingDAO.GetToppingDescription("Guacamole") + "\n";
		}

		public override int GetPrice()
		{
			return base.GetPrice() + ToppingDAO.GetToppingPrice("Guacamole");
		}
	}
}

