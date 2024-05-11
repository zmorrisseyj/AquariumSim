
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
