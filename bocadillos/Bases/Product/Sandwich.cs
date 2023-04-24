using System;
using bocadillos.Bases;

namespace bocadillos;

public abstract class Sandwich
{
    public int Id { get; set; }
    public string? Name { get; set; }

    protected int _price;
    protected string? _description;

    public abstract int GetPrice();
    public abstract string? GetDescription();
}

