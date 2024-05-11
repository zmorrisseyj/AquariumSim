using Aquarium.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Models.Species
{
    public class Pleco : Fish
    {
        
        public Pleco(string nm, string dsc, double wt, double len, Color clr) 
            : base(nm, dsc, wt, len, clr, 3)
        {

        }

        public override void Swim(double hours, Tank tank)
        {
            base.Swim(hours, tank);
            EatAlgae(tank);
        }

        public override void Poop()
        {
            if(FoodInStomach > 0)
            {
                Console.WriteLine($"{this.Name} pooped.");
                FoodInStomach -= 2;
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

        public void EatAlgae(Tank tank)
        {
            if (tank.AlgaeLevel > 0 && FoodInStomach < StomachSize)
            {
                int NumHungryPlecos = tank.Species.Where(s => s.GetType() == typeof(Pleco) && s.FoodInStomach < StomachSize).Count();
                double AlgaeToEat = tank.AlgaeLevel / NumHungryPlecos;
                AlgaeToEat = AlgaeToEat > 1 ? 1 : AlgaeToEat;

                this.FoodInStomach++;
                tank.AlgaeLevel-=AlgaeToEat;
                Console.WriteLine($"{Name} the pleco ate {AlgaeToEat} algae. The amount of algae in the tank is now {tank.AlgaeLevel}.");
            }
            else if(FoodInStomach >= StomachSize)
            {
                Console.WriteLine($"{Name} the pleco was too full to eat any algae.");
            }
        }
    }
}
