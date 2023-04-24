using System;
namespace bocadillos.Bases
{
    public class PlainWheatSandwich : Sandwich
    {
        public PlainWheatSandwich()
        {
            Name = "Plain wheat bread";
            _description = "Plain wheat bread with: \n";
            _price = 30;
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




