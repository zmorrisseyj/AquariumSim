using Aquarium.Interfaces;
using Aquarium.Models.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Models
{
    public class Fish : IAquatic
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Age { get; set; }
        public Color Color { get; set; }
        public double DistanceSwam { get; set; } = 0;
        public double StomachSize { get; set; } = 10;
        public double FoodInStomach { get; set; } = 0;
        public double Speed { get; set; }

        public Fish(string nm, string dsc, double wt, double len, double a, Color clr, double spd)
        {
            Name = nm;
            Description = dsc;
            Weight = wt;
            Length = len;
            Age = a;
            Color = clr;
            Speed = spd;
        }

        public virtual void Swim(double seconds, Tank tank)
        {
            double distance = this.Speed * seconds;
            Console.WriteLine($"{this.Name} swam for {seconds} seconds and covered a distance of {distance} meters in tank {tank.Name}");

        }

        public void Eat(double food)
        {
            if(FoodInStomach + food <= StomachSize)
            {
                FoodInStomach += food;
                Console.Write($"{this.Name} ate {food} fish flakes.");
            }
            else
            {
                Console.Write($"{this.Name} is too full to eat all {food} fish flakes. It only ate {StomachSize - FoodInStomach} fish flakes");
                FoodInStomach = StomachSize;
            }
        }

        public virtual void Poop()
        {
            if(FoodInStomach > 0)
            {
                Console.WriteLine($"{this.Name} pooped.");
                FoodInStomach--;
            }

            if(FoodInStomach < 0)
            {
                FoodInStomach = 0;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine();
            foreach (var prop in GetType().GetProperties())
            {
                Console.WriteLine($"{prop.Name} - {prop.GetValue(this)}");
            }
        }
    }
}
