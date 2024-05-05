using Aquarium.Models.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Models
{
    public class Aquarium
    {
        public List<Tank> Tanks { get; set; }

        public Aquarium()
        {
            Tanks = new List<Tank>()
            {

            }
        }
    }
}
