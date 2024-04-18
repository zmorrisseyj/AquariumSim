using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Fish
{
    public class Betta : Fish
    {

        public Betta(string nm, string dsc, double wt, double len, Color clr, double dst, double hrs, double spd = 10) : base (nm, dsc, wt, len, clr, dst, hrs, spd)
        {
            
        }

        public void Flare()
        {

        }

        public void Unflare()
        {

        }
    }
}
