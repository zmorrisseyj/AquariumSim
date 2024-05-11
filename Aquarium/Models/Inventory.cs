
namespace Aquarium.Models
{
    public class Inventory
    {
        public List<Tank> Tanks { get; set; }

        public Inventory()
        {
            Tanks = new List<Tank>();
        }

        public Inventory(List<Tank> tanks)
        {
            Tanks = tanks;
        }

        public void DisplayAllContents()
        {
            Console.WriteLine($"\nNumber of tanks: {Tanks.Count()}\n");

            for(int i = 0; i < Tanks.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Tank #{i + 1}:".PadLeft(19));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Tanks[i].DisplayContents();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void AddTank()
        {

            Console.WriteLine($"Please enter name for tank: ");
            string name = Console.ReadLine();

            double? volume = null;
            do
            {
                Console.WriteLine($"Please enter the tank volume (gallons): ");
                string input = Console.ReadLine();
                double volTemp = 0;
                if (double.TryParse(input, out double volParsed))
                {
                    volTemp = volParsed;
                    if (volTemp <= 0)
                    {
                        Console.WriteLine($"Invalid tank volume. Please enter positive number.");
                    }
                    else
                    {
                        volume = volTemp;
                    }
                }
                else{ Console.WriteLine($"Invalid tank volume. Please enter a decimal value."); }
            }
            while (volume is null);

            Tank newTank = new(name,(double)volume);
            string selection = String.Empty;

            Console.WriteLine($"Would you like to add a fish?");
            do
            {
                Console.WriteLine($"1: Add new fish\n" +
                    $"0: Done adding fish\n");
                selection = Console.ReadLine();
                switch(selection)
                {
                    case "1":
                        newTank.AddFish();
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
            while (selection != "0");

            this.Tanks.Add(newTank);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Tank {newTank.Name} added.\n");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        internal void AddSpecies()
        {
            int index = SelectTank();
            if(index < 0)
            {
                return;
            }
            Tanks[index].AddFish();
        }

        internal void Tick()
        {
            foreach(var tank in Tanks)
            {
                tank.Tick();
            }
        }

        internal void Feed()
        {
            int index = SelectTank();

            double amountToFeed = 0;

            Console.WriteLine($"Please enter the amount of food to put into tank {Tanks[index].Name}:");
            do
            {
                string input = Console.ReadLine();

                double tempVal = 0;

                if (double.TryParse(input, out double result))
                {
                    tempVal = result;
                }
                else
                {
                    Console.WriteLine($"{input} is not a valid input for food amount. Please enter a decimal number.");
                }

                if (tempVal <= 0)
                {
                    Console.WriteLine($"{input} is not a valid input for food amount. Please enter a positive number.");
                }
                else
                {
                    amountToFeed = tempVal;
                }
            }
            while (amountToFeed == 0);

            Tanks[index].Feed(amountToFeed);
            Console.WriteLine();
        }

        public int SelectTank()
        {
            Console.WriteLine($"Select a fishtank:");

            List<string> options = Tanks.Select((x, i) => (i + 1).ToString()).ToList();
            options.Add("0");

            string selection = String.Empty;
            do
            {
                if (selection != string.Empty)
                {
                    Console.WriteLine("Invalid selection");
                }

                for (int i = 0; i < this.Tanks.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}:");
                    Console.WriteLine(Tanks[i]);
                }
                Console.WriteLine("0: Cancel");

                selection = Console.ReadLine();
            }
            while (!options.Contains(selection));

            if (selection == "0")
            {
                return -1;
            }
            else
            {
                return int.Parse(selection) - 1;
            }
        }

        internal void MoveFish()
        {
            if (Tanks.Count() < 2)
            {
                Console.WriteLine("You only have 1 fish tank! Add another tank if you want to move a fish.");
            }
            else
            {
                Console.WriteLine("Choose source tank.");
                int sourceTankIndex = SelectTank();
                int fish = 0;
                if(sourceTankIndex < 0)
                {
                    return;
                }
                else if(Tanks[sourceTankIndex].Species.Count() < 1)
                {
                    Console.WriteLine($"{Tanks[sourceTankIndex].Name} doesn't have any fish in it for you to move!");
                    return;
                }
                else
                {
                    fish = Tanks[sourceTankIndex].SelectFish();
                    if(fish < 0)
                    {
                        return;
                    }
                }

                Console.WriteLine($"Choose destination tank.");
                int targetTankIndex = SelectTank();
                if(targetTankIndex < 0)
                {
                    return;
                }

                if(sourceTankIndex == targetTankIndex)
                {
                    Console.WriteLine($"Source and target tank are the same, nothing happened");
                    return;
                }

                Fish toMove = Tanks[sourceTankIndex].Species[fish];
                Tanks[targetTankIndex].Species.Add(toMove);
                Tanks[sourceTankIndex].Species.Remove(toMove);
                Console.WriteLine($"Moved {toMove.Name} from {Tanks[sourceTankIndex].Name} to {Tanks[targetTankIndex].Name}");
                
            }
            
        }
    }
}
