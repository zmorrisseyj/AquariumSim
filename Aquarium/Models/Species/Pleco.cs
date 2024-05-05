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
        
        public Pleco(string nm, string dsc, double wt, double len, double a, Color clr, double spd = 5) 
            : base(nm, dsc, wt, len, a, clr, spd)
        {

        }


        public void EatAlgae(Tank tank)
        {

        }
    }
}
