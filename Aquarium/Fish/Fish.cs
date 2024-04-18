using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Fish
{
    public class Fish
    {
        private string name;
        private string description;
        private double weight;
        private double length;
        private Color color;
        private double distanceSwam;
        private double hoursInTank;
        private double speed;
        private double foodEaten;

        public Fish(string nm, string dsc, double wt, double len, Color clr, double dst, double hrs, double spd = 0, double fe = 0)
        {
            Name = nm;
            Description = dsc;
            Weight = wt;
            Length = len;
            Color = clr;
            DistanceSwam = dst;
            HoursInTank = hrs;
            Speed = spd;
            FoodEaten = fe;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value < 0 ? 0 : value;
            }
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value < 0 ? 0 : value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public double DistanceSwam
        {
            get
            {
                return distanceSwam;
            }
            set
            {
                distanceSwam = value < 0 ? 0 : value;
            }
        }

        public double HoursInTank
        {
            get
            {
                return hoursInTank;
            }
            set
            {
                hoursInTank = value < 0 ? 0 : value;
            }
        }

        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value < 0 ? 0 : value;
            }
        }

        public double FoodEaten
        {
            get
            {
                return foodEaten;
            }
            set
            {
                foodEaten = value < 0 ? 0 : value;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine();
            foreach(var prop in this.GetType().GetProperties())
            {
                Console.WriteLine($"{prop.Name} - {prop.GetValue(this)}");
            }
        }

        public void Swim(double hours)
        {
            DistanceSwam += Speed * hours;
            HoursInTank += hours;
            Console.WriteLine($"\n{this.Name} swam a distance of {Speed * hours} in {hours} hours.");
        }

        public void Eat(double food)
        {
            Weight += food;
            FoodEaten += food;
            Console.WriteLine($"\n{this.Name} ate {food} food{(food > 1 ? "s" : "")}.");
        }

        public void Poop()
        {
            if(FoodEaten > 0 ){
                Weight -= 1;
                FoodEaten -= 1;
                FoodEaten = FoodEaten < 0 ? 0 : FoodEaten;
                Console.WriteLine($"\n{this.Name} pooped.");
            }
            else
            {
                Console.WriteLine($"\n{this.Name} has no poop for pooping!");
            }
        }
    }
}
