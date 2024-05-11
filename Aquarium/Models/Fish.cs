using Aquarium.Interfaces;
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
        public Color Color { get; set; }
        public double DistanceSwam { get; set; } = 0;
        public double StomachSize { get; set; } = 10;
        public double FoodInStomach { get; set; } = 0;
        public double TimeHungry { get; set; } = 0;
        public double Speed { get; set; }

        public Fish(string nm, string dsc, double wt, double len, Color clr, double spd)
        {
            Name = nm;
            Description = dsc;
            Weight = wt;
            Length = len;
            Color = clr;
            Speed = spd;
        }

        public override string ToString()
        {
            return $"{Name} - {this.GetType().ToString().Split('.').Last()}";
        }


        public virtual void Swim(double hours, Tank tank)
        {
            double distance = this.Speed * hours;
            DistanceSwam += distance;
            Console.WriteLine($"{this.Name} swam for {hours} {(hours > 1 ? "hours" : "hour")} and covered a distance of {distance} meters in tank {tank.Name}");
        }

        public void Eat(double food)
        {
            if(FoodInStomach + food <= StomachSize)
            {
                FoodInStomach += food;
                Console.WriteLine($"{this.Name} ate {food} fish flakes.");
            }
            else
            {
                Console.WriteLine($"{this.Name} is too full to eat all {food} fish flakes. It only ate {StomachSize - FoodInStomach} fish flakes");
                FoodInStomach = StomachSize;
            }
            TimeHungry = 0;
        }

        public virtual void Poop()
        {
            if(FoodInStomach > 0)
            {
                Console.WriteLine($"{this.Name} pooped.");
                FoodInStomach--;
            }
            else if (FoodInStomach == 0)
            {
                TimeHungry++;
            }

            if (FoodInStomach < 0)
            {
                FoodInStomach = 0;
            }
        }

        public void DisplayInfo()
        {
            foreach (var prop in GetType().GetProperties())
            {
                Console.WriteLine(string.Format("{0,-15} - {1}", prop.Name.PadLeft(15), prop.GetValue(this)));
            }
        }
    }
}
