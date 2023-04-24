using bocadillos.Bases;
using bocadillos.Controllers;
using System;
namespace bocadillos.Decorators
{
    public class HamTopping : ToppingDecorator
    {
		public HamTopping(Sandwich baseSandwich) : base(baseSandwich)
        {
        }
        
        public override string GetDescription()
		{
			return base.GetDescription() + ToppingDAO.GetToppingDescription("Ham") + "\n";
		}

		public override int GetPrice()
		{
			return base.GetPrice() + ToppingDAO.GetToppingPrice("Ham");
		}
	}
}

