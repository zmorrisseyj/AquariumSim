using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Models.Tanks
{
    public class Tank
    {
        public string Name { get; set; }
        public double Volume { get; set; }
        public List<Fish> Species { get; set; } = new List<Fish>();

        public Tank(string name)
        {
            Name = name;
        }

        public Tank(string name, double vol) :
            this(name)
        { 
            Volume = vol;
        }

        public Tank(string name, double vol, List<Fish> sp) :
            this(name, vol)
        {
            Species = sp;
        }

        public void DisplayContents()
        {
            Console.WriteLine(
                $"Tank name: {this.Name}\n" +
                $"Tank volume: {this.Volume}\n" +
                $"Tank species: \n");
            foreach(var s in Species)
            {
                s.DisplayInfo();
            }
        }
    }
}
