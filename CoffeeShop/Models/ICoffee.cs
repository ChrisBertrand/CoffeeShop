using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public interface ICoffee
    {
        int Id { get; set; }
        string Name { get; set; }
        int Temperature { get;}
        double Cost { get;}
        int Calories { get;}
        int Liquid { get; set; }
        void Drink();
    }

    public class BaseCoffee : ICoffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Temperature { get => 42;}
        public double Cost { get => .99;}
        public int Calories { get => 100;}
        public int Liquid { get; set; } = 330;

        public void Drink()
        {
           Liquid += -10;
        }
    }

    [DebuggerDisplay("Liquid Levels: {liquid}")]
    public class Americano : ICoffee
    {
        private readonly ICoffee _decoratedCoffee;

        public Americano(ICoffee decoratedCoffee)
        {
            _decoratedCoffee = decoratedCoffee;
            liquid = _decoratedCoffee.Liquid;
    }

        public int Id { get; set; }
        public string Name { get; set; } = "Americano";
        public int Temperature { get => _decoratedCoffee.Temperature - 5; }
        public double Cost { get => _decoratedCoffee.Cost; }
        public int Calories { get => _decoratedCoffee.Calories; }

        private int liquid;
        public int Liquid { get => liquid; set => liquid =- value; }

        public void Drink()
        {
            _decoratedCoffee.Drink();
            liquid = _decoratedCoffee.Liquid;
        }
    }

    [DebuggerDisplay("Liquid Levels: {liquid}")]
    public class CaramelCreamLatte : ICoffee
    {
        private readonly ICoffee _decoratedCoffee;

        public CaramelCreamLatte(ICoffee decoratedCoffee)
        {
            _decoratedCoffee = decoratedCoffee;
            liquid = _decoratedCoffee.Liquid;
        }

        public int Id { get; set; }
        public string Name { get => _decoratedCoffee.Name; set => Name = value; }
        public int Temperature { get => _decoratedCoffee.Temperature - 20; }
        public double Cost { get => _decoratedCoffee.Cost + 100; }
        public int Calories { get => _decoratedCoffee.Calories + 200; }
        private int liquid;
        public int Liquid { get => _decoratedCoffee.Liquid; set => _decoratedCoffee.Liquid =- value; }

        public void Drink()
        {
            _decoratedCoffee.Drink();
            liquid = _decoratedCoffee.Liquid;
        }
    }
}
