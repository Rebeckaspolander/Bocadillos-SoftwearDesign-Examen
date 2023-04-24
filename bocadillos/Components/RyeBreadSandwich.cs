using System;
namespace bocadillos.Components
{
    public class RyeBreadSandwich : Sandwich
    {
        public RyeBreadSandwich()
        {
            Name = "Rye bread";
            _description = "Rye bread bread with: \n";
            _price = 40;
        }

        public override int GetPrice()
        {
            return _price;
        }

        public override string? GetDescription()
        {
            return _description;
        }
    }
}

