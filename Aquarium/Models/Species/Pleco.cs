using Aquarium.Interfaces;
using Aquarium.Models.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Models.Species
{
    public class Pleco : Fish
    {
        
        public Pleco(string nm, string dsc, double wt, double len, double a, Color clr) 
            : base(nm, dsc, wt, len, a, clr, 3)
        {

        }

        public override void Swim(double seconds, Tank tank)
        {
            base.Swim(seconds, tank);
            EatAlgae(tank);
        }

        public override void Poop()
        {
            if(FoodInStomach > 0)
            {
                Console.WriteLine($"{this.Name} pooped.");
                FoodInStomach -= 0.5;
            }

            if (FoodInStomach < 0)
            {
                FoodInStomach = 0;
            }
        }

        public void EatAlgae(Tank tank)
        {
            if(tank.AlgaeAmount > 0)
            {
                this.FoodInStomach++;
                tank.AlgaeAmount--;
                Console.WriteLine($"{Name} the pleco ate some algae. The amount of algae in the tank is now {tank.AlgaeAmount}.");
            }
        }
    }
}
