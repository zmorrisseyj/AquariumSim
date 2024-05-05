using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Interfaces
{
    public interface IAquatic
    {
        public void DisplayInfo();

        public void Swim(double hours);

        public void Eat(double food);

        public void Poop();
    }
}
