using Aquarium;
using Aquarium.Models;
using Aquarium.Models.Species;

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\n\nWelcome to Zach's Aquarium!\n\n");
Console.ForegroundColor = ConsoleColor.Gray;

Inventory inventory = new Inventory(new List<Tank>
{
    new Tank("Zach's Goldfish Tank",10,new List<Fish>
    {
        new Goldfish("Appa", "White goldfish with orange dot on his head", 5.6, 4.5, Color.White),
        new Goldfish("Momo", "Orange goldfish with black markings", 8.1, 6.7, Color.Orange),
        new Goldfish("Floppsy", "Gray goldfish with white markings", 8.9, 7.1, Color.Gray),
    }),
    new Tank("Kendall's Betta Tank",15,new List<Fish>
    {
        new Betta("Appa", "Blue body with rainbow fins", 4.0, 6.8, Color.Blue),
    }),
});

string selection = String.Empty;

do
{
    Console.WriteLine(
        $"Please type a number to select an action:\n" +
        $"1: Display current aquarium contents\n" +
        $"2: Add new tank\n" +
        $"3: Add new species\n" +
        $"4: Watch aquarium\n" +
        $"5: Feed fish\n" +
        $"6: Move fish\n" +
        $"0: Exit aquarium\n");

    selection = Console.ReadLine();

    switch (selection)
    {
        case "1":
            inventory.DisplayAllContents();
            break;

        case "2":
            inventory.AddTank();
            break;

        case "3":
            inventory.AddSpecies();
            break;

        case "4":
            inventory.Tick();
            break;

        case "5":
            inventory.Feed();
            break;

        case "6":
            inventory.MoveFish();
            break;

        case "0":
            break;

        default:
            Console.WriteLine("Invalid selection.");
            break;

    }
}
while (selection != "0");

Console.WriteLine("Simulation ended. Press any key to exit.");
Console.ReadLine();
