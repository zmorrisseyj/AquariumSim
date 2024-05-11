using Aquarium.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Models.Species
{
    public class Betta : Fish
    {

        public Betta(string nm, string dsc, double wt, double len, Color clr)
            : base(nm, dsc, wt, len, clr, 5)
        {

        }

        public override void Poop()
        {
            if (FoodInStomach > 0)
            {
                Console.WriteLine($"{this.Name} pooped.");
                FoodInStomach -= 0.5;
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

        public override void Swim(double hours, Tank tank)
        {
            base.Swim(hours, tank);
            Fight(tank);
        }

        public void Fight(Tank tank)
        {
            if(tank.Species.Count() > 1)
            {
                for(int i = 0; i < tank.Species.Count(); i++)
                {
                    if (tank.Species[i] != this)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Oh no! You put a betta in a tank with another fish. {Name} killed {tank.Species[i]} :(.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        tank.deadFish.Add(tank.Species[i]);
                        return;
                    }
                }
            }
        }
    }
}
