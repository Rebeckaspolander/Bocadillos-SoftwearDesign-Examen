using bocadillos.Bases;
using bocadillos.Controllers;
using System;
namespace bocadillos.Decorators
{
    public class TurkeyTopping : ToppingDecorator
    {
        public TurkeyTopping(Sandwich baseSandwich) : base(baseSandwich)
        {
        }

		public override string GetDescription()
		{
			return base.GetDescription() + ToppingDAO.GetToppingDescription("Turkey") + "\n";
		}
		public override int GetPrice()
		{
			return base.GetPrice() + ToppingDAO.GetToppingPrice("Turkey");
		}
	}
}

