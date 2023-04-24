namespace BocadillosTests;
using System;
using bocadillos;
using bocadillos.Bases;
using bocadillos.Controllers;
using bocadillos.DB;
using bocadillos.Decorators;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        DbConnect.DropDataBase();
        DbConnect.CreateDb();
        ToppingDAO.AddToppingsToDatabase();
    }

    [Test]
    public void TestPriceIsUpdated()
    {
        Sandwich sandwich = new PlainWheatSandwich();
        var sandwichWithHam = new HamTopping(sandwich);

        Assert.That(sandwichWithHam.GetPrice(), Is.EqualTo(40));
    }

    [Test]
    public void TestDescriptionIsUpdated()
    {
        Sandwich sandwich = new PlainWheatSandwich();
        var sandwichWithHam = new HamTopping(sandwich);

        Assert.That(sandwichWithHam.GetDescription(), Is.EqualTo("Plain wheat bread with: \nA slice of ham (from a pig)\n"));
    }

}