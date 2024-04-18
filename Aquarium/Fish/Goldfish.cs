using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Fish
{
    public class Goldfish : Fish
    {
        public Goldfish(string nm, string dsc, double wt, double len, Color clr, double dst, double hrs, double spd = 15) : base(nm, dsc, wt, len, clr, dst, hrs, spd)
        {
            
        }


    }
}
