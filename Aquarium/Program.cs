


Console.WriteLine($"Welcome to Zach's Aquarium!");

string selection = String.Empty;

do
{
    Console.WriteLine(
        $"Please type a number to select an action:\n" +
        $"1: Display current aquarium contents\n" +
        $"2: Add new species\n" +
        $"3: Watch aquarium\n" +
        $"");
}
while (selection != "0");

Console.WriteLine("Simulation ended. Press any key to exit.");
Console.ReadLine();
