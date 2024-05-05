using Aquarium.Interfaces;
using Aquarium.Models.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Models.Species
{
    public class Betta : Fish
    {

        public Betta(string nm, string dsc, double wt, double len, double a, Color clr)
            : base(nm, dsc, wt, len, a, clr, 5)
        {

        }

        public override void Swim(double seconds, Tank tank)
        {
            base.Swim(seconds, tank);
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
                        Console.WriteLine($"Oh no! You put a betta in a tank with another fish. {Name} killed {tank.Species[i]} :(.");
                        tank.Species.RemoveAt(i);
                        return;
                    }
                }
            }
        }
    }
}
