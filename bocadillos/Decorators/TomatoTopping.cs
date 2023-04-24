using bocadillos.Bases;
using bocadillos.Controllers;
using System;
namespace bocadillos.Decorators
{
    public class TomatoTopping : ToppingDecorator
    {
		public TomatoTopping(Sandwich baseSandwich) : base(baseSandwich)
        {
        }

		public override string GetDescription()
		{
			return base.GetDescription() + ToppingDAO.GetToppingDescription("Tomato") + "\n";
		}

		public override int GetPrice()
		{
			return base.GetPrice() + ToppingDAO.GetToppingPrice("Tomato");
		}
	}
}

 