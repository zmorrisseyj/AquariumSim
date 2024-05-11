using Aquarium.Models.Species;

namespace Aquarium.Models
{
    public class Tank
    {
        public string Name { get; set; }
        public double Volume { get; set; }
        public double AlgaeLevel { get; set; }
        public List<Fish> Species { get; set; } = new List<Fish>();

        public List<Fish> deadFish { get; set; } = new List<Fish>();

        public Tank(string name)
        {
            Name = name;
            AlgaeLevel = 0;
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

        public override string ToString()
        {
            return string.Format("{0,-15} - {1}\n", $"Name".PadLeft(15), Name)
                + string.Format("{0,-15} - {1}\n", $"Volume".PadLeft(15), $"{Volume} gallons")
                + string.Format("{0,-15} - {1}\n", $"Number of fish".PadLeft(15), Species.Count())
                + string.Format("{0,-15} - {1}\n", $"Algae level".PadLeft(15), AlgaeLevel);
        }

        public void DisplayContents()
        {
            Console.WriteLine(this);
            for(int i = 0; i < Species.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(string.Format("{0,-15} - {1}", $"Fish #".PadLeft(15), i+1));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Species[i].DisplayInfo();
                Console.WriteLine();
            }
        }

        public void Tick()
        {
            if (!Species.Any())
            {
                Console.WriteLine($"Tank {Name} doesn't have any fish in it!");
                return;
            }

            Console.WriteLine($"1 hour passed.");
            foreach (var s in Species)
            {
                if (!deadFish.Contains(s))
                {
                    s.Swim(1, this);
                    s.Poop();
                    if (s.TimeHungry > 3)
                    {
                        deadFish.Add(s);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{s.Name} starved to death :(");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (s.TimeHungry > 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{s.Name} is close to starving to death!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (s.TimeHungry > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{s.Name} is getting really hungry!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (s.TimeHungry > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{s.Name} is getting hungry!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }

            foreach(var s in deadFish)
            {
                Species.Remove(s);
            }
            deadFish = new List<Fish>();

            AlgaeLevel++;

            Console.WriteLine();
        }

        public void Feed(double food)
        {
            foreach (var s in Species)
            {
                s.Eat(Math.Round(food / Species.Count(),2));
            }
        }

        public int SelectFish()
        {
            Console.WriteLine($"Select a fish:");

            List<string> options = Species.Select((x, i) => (i + 1).ToString()).ToList();
            options.Add("0");

            string selection = String.Empty;
            do
            {
                if (selection != string.Empty)
                {
                    Console.WriteLine("Invalid selection");
                }

                for (int i = 0; i < Species.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}: {Species[i]}");
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

        public void AddFish()
        {
            Console.WriteLine($"What kind of fish would you like to add?\n");

            string selection = string.Empty;

            do
            {
                if (selection != string.Empty)
                {
                    Console.WriteLine($"Invalid choice.");
                }

                Console.WriteLine(
                    $"1: Betta\n" +
                    $"2: Goldfish\n" +
                    $"3: Pleco\n" +
                    $"0: Cancel\n");

                selection = Console.ReadLine();
            }
            while (!new List<string> { "1", "2", "3", "0" }.Contains(selection));

            if (selection == "0")
            {
                Console.WriteLine($"Did not add fish to {Name}");
                return;
            }

            else
            {
                //give Name
                Console.WriteLine("Please enter a name for the fish:");
                string nm = Console.ReadLine();

                //give Description
                Console.WriteLine("Please enter any special attributes of the fish:");
                string dsc = Console.ReadLine();

                //give Weight
                double wt = 0;
                do
                {
                    Console.WriteLine($"Please enter the weight of the fish (grams):");

                    string input = Console.ReadLine();

                    double tempWt = 0;

                    if (double.TryParse(input, out double result))
                    {
                        tempWt = result;
                        if (tempWt <= 0)
                        {
                            Console.WriteLine($"{input} is not a valid input for weight. Please enter a positive number.");
                        }
                        else
                        {
                            wt = tempWt;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{input} is not a valid input for weight. Please enter a decimal number.");
                    }
                }
                while (wt == 0);


                //give Length
                double len = 0;
                do
                {
                    Console.WriteLine($"Please enter the length of the fish (centimeters):");

                    string input = Console.ReadLine();

                    double tempLen = 0;

                    if (double.TryParse(input, out double result))
                    {
                        tempLen = result;
                        if (tempLen <= 0)
                        {
                            Console.WriteLine($"{input} is not a valid input for length. Please enter a positive number.");
                        }
                        else
                        {
                            len = tempLen;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{input} is not a valid input for length. Please enter a decimal number.");
                    }
                }
                while (len == 0);

                //give color
                dynamic clr = null;
                string inputClr;
                do
                {
                    Console.WriteLine(
                        $"Please enter the color of the fish.\n\n" +
                        $"Options:\n" +
                        $"{string.Join(",\n", Enum.GetNames(typeof(Aquarium.Color)))}");

                    inputClr = Console.ReadLine();

                    if(!(inputClr is null)) //convert case
                    {
                        inputClr = inputClr.Substring(0,1).ToUpper() + inputClr.Substring(1).ToLower();
                    }

                    if(Enum.TryParse(inputClr, out Aquarium.Color tempClr))
                    {
                        clr = tempClr;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                }
                while (clr is null);


                switch (selection)
                {
                    case "1":
                        //Betta
                        Species.Add(new Betta(nm, dsc, wt, len, clr));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Betta {nm} added :)\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    case "2":
                        //Goldfish
                        Species.Add(new Goldfish(nm, dsc, wt, len, clr));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Goldfish {nm} added :)\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    case "3":
                        //Pleco
                        Species.Add(new Pleco(nm, dsc, wt, len, clr));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Pleco {nm} added :)\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"An error has occured. You never should have come here!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;

                }
            }
        }
    }
}
