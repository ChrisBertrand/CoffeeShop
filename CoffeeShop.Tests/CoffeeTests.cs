using System;
using Xunit;
using CoffeeShop;
using CoffeeShop.Models;

namespace CoffeeShop.Tests
{
    public class CoffeeTests
    {
        private ICoffee _baseCoffee;

        public CoffeeTests()
        {
            _baseCoffee = new BaseCoffee();
        }

        [Fact]
        public void BaseCofee_ReturnedCorrectly()
        {
            var coffee = _baseCoffee;
            Assert.True(coffee.Temperature == 42, "Coffee should be 42 Degs");
        }

        [Fact]
        public void Americano_ReturnedCorrectly()
        {
            var coffee = new Americano(_baseCoffee);
            bool condition = coffee.Temperature == 37;
            Assert.True(condition, "Coffee should be 37 Degs");
            Assert.True(coffee.Name == "Americano", $"Should be called Americano not ${coffee.Name}");
            coffee.Name = "Chilled Americano";
            Assert.True(coffee.Name == "Chilled Americano", $"Should be called Chilled Americano not ${coffee.Name}");
            Assert.Equal(330, coffee.Liquid);
            coffee.Drink();
            Assert.Equal(320, coffee.Liquid);
            coffee.Drink();
            Assert.Equal(310, coffee.Liquid);
        }

    }
}
