using System;
namespace bocadillos.Components
{
    public class SourdoughSandwich : Sandwich
    {
        public SourdoughSandwich()
        {
            Name = "Sourdough bread";
            _description = "Sourdough bread with: \n";
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

