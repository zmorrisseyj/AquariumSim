using Aquarium.Models.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium.Models.Tanks
{
    public class Tank
    {
        public string Name { get; set; }
        public double Volume { get; set; }
        public double AlgaeAmount { get; set; }
        public List<Fish> Species { get; set; } = new List<Fish>();

        public Tank(string name)
        {
            Name = name;
            AlgaeAmount = 0;
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

        public void Tick()
        {
            Console.WriteLine($"1 hour passed.");
            foreach(var s in Species)
            {
                s.Swim(1,this);
                s.Poop();
            }

            AlgaeAmount++;
        }

        public void Feed(double food)
        {
            foreach(var s in Species)
            {
                s.Eat(food / Species.Count());
            }
        }

        public void AddFish()
        {
            Console.WriteLine($"What kind of fish would you like to add?\n");
                
            string selection = string.Empty;

            do
            {
                if(selection != string.Empty)
                {
                    Console.WriteLine($"Invalid choice.");
                }

                Console.WriteLine(
                    $"1: Betta\n" +
                    $"2: Goldfish\n" +
                    $"3: Pleco\n" +
                    $"0: Cancel\n");
            }
            while (!new List<string> { "1", "2", "3", "0"}.Contains(selection));

            if(selection == "0")
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
                    Console.WriteLine($"Please enter the wieght of the fish (grams):");

                    string input = Console.ReadLine();

                    double tempWt = 0;

                    if (double.TryParse(input, out double result))
                    {
                        tempWt = result;
                    }
                    else
                    {
                        Console.WriteLine($"{input} is not a valid input for weight. Please enter a decimal number.");
                    }

                    if(tempWt <= 0)
                    {
                        Console.WriteLine($"{input} is not a valid input for weight. Please enter a positive number.");
                    }
                    else
                    {
                        wt = tempWt;
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
                    }
                    else
                    {
                        Console.WriteLine($"{input} is not a valid input for length. Please enter a decimal number.");
                    }

                    if (tempLen <= 0)
                    {
                        Console.WriteLine($"{input} is not a valid input for length. Please enter a positive number.");
                    }
                    else
                    {
                        len = tempLen;
                    }
                }
                while (len == 0);


                //give Age
                double a = 0;
                do
                {
                    Console.WriteLine($"Please enter the age of the fish (days):");

                    string input = Console.ReadLine();

                    double tempAge = 0;

                    if (double.TryParse(input, out double result))
                    {
                        tempAge = result;
                    }
                    else
                    {
                        Console.WriteLine($"{input} is not a valid input for age. Please enter a decimal number.");
                    }

                    if (tempAge <= 0)
                    {
                        Console.WriteLine($"{input} is not a valid input for age. Please enter a positive number.");
                    }
                    else
                    {
                        a = tempAge;
                    }
                }
                while (a == 0);


                dynamic clr = null;
                string inputClr;
                do
                {
                    Console.WriteLine(
                        $"Please enter the color of the fish.\n\n" +
                        $"Options:\n" +
                        $"White,\n" +
                        $"Black,\n" +
                        $"Red,\n" +
                        $"Green,\n" +
                        $"Blue,\n" +
                        $"Yellow,\n" +
                        $"Orange,\n" +
                        $"Purple,\n" +
                        $"Pink,\n" +
                        $"Brown");

                    inputClr = Console.ReadLine();

                    switch(inputClr){
                        case "White":
                            clr = Color.White;
                            break;
                        case "Black":
                            clr = Color.Black;
                            break;
                        case "Red":
                            clr = Color.Red;
                            break;
                        case "Green":
                            clr = Color.Green;
                            break;
                        case "Blue":
                            clr = Color.Blue;
                            break;
                        case "Yellow":
                            clr = Color.Yellow;
                            break;
                        case "Orange":
                            clr = Color.Orange;
                            break;
                        case "Purple":
                            clr = Color.Purple;
                            break;
                        case "Pink":
                            clr = Color.Pink;
                            break;
                        case "Brown":
                            clr = Color.Brown;
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            clr = null;
                            break;
                    }
                }
                while (clr is null);



                switch (selection)
                {
                    case "1":
                        //Betta
                        this.Species.Add(new Betta(nm, dsc, wt, len, a, clr));
                        Console.WriteLine($"Fish added :)");
                        return;
                    case "2":
                        //Goldfish
                        this.Species.Add(new Goldfish(nm, dsc, wt, len, a, clr));
                        Console.WriteLine($"Fish added :)");
                        return;
                    case "3":
                        //Pleco
                        this.Species.Add(new Pleco(nm, dsc, wt, len, a, clr));
                        Console.WriteLine($"Fish added :)");
                        return;
                    default:
                        Console.WriteLine($"An error has occured. You never should have come here!");
                        return;

                }
            }
        }
    }
}
