using Aquarium.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Models.Species
{
    public class Goldfish : Fish
    {
        public Goldfish(string nm, string dsc, double wt, double len, double a, Color clr)
            : base(nm, dsc, wt, len, a, clr, 10)
        {

        }


        public override void Poop()
        {
            if (FoodInStomach > 0)
            {
                Console.WriteLine($"{this.Name} pooped.");
                FoodInStomach -= 2;
            }

            if (FoodInStomach < 0)
            {
                FoodInStomach = 0;
            }
        }
    }
}
