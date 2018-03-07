using System;
using System.Collections.Generic;
using System.Linq;

namespace ExploreCollections
{
    class Auto
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int Price;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var autos = new List<Auto>();
            autos.Add(new Auto { Name = "SUV", MaxSpeed = 101, Price = 2000 });
            autos.Add(new Auto { Name = "Sedan", MaxSpeed = 120, Price = 1000 });
            autos.Add(new Auto { Name = "Coupe", MaxSpeed = 110, Price = 3000 });

            var auto = autos.OrderBy(x => x.Price).First();
            Console.WriteLine("Lowest Price: Name={0} Price={1}", auto.Name, auto.Price);
            auto = autos.OrderBy(x => x.MaxSpeed).Last();
            Console.WriteLine("Fastest Speed: Name={0} Speed={1}", auto.Name, auto.MaxSpeed);

            Console.ReadLine();
        }
    }
}