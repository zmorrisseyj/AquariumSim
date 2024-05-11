using Aquarium.Models;

namespace Aquarium.Interfaces
{
    public interface IAquatic
    {
        public void DisplayInfo();

        public void Swim(double hours, Tank tank);

        public void Eat(double food);

        public void Poop();
    }
}
