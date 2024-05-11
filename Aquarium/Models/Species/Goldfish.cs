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
        public Goldfish(string nm, string dsc, double wt, double len, Color clr)
            : base(nm, dsc, wt, len, clr, 10)
        {

        }
    }
}
