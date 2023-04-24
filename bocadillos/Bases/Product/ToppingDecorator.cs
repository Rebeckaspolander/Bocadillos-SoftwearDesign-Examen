using System;
using bocadillos.Decorators;
using bocadillos.Bases;

namespace bocadillos;

public abstract class ToppingDecorator: Sandwich
{
    private readonly Sandwich _baseSandwich;

    protected ToppingDecorator(Sandwich baseSandwich)
    {
        _baseSandwich = baseSandwich;
    }

    public override string GetDescription()
    {
        return _baseSandwich.GetDescription();
    }

    public override int GetPrice()
    {
        return _baseSandwich.GetPrice();
    }
}

