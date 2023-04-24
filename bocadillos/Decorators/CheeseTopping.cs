using bocadillos.Controllers;
using System;
namespace bocadillos.Bases
{
    public class CheeseTopping : ToppingDecorator
    {
		public CheeseTopping(Sandwich baseSandwich) : base(baseSandwich)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ToppingDAO.GetToppingDescription("Cheese") + "\n";
        }

        public override int GetPrice()
        {
            return base.GetPrice() + ToppingDAO.GetToppingPrice("Cheese");
        }
    }
}

