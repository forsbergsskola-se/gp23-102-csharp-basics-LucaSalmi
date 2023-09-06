// See https://aka.ms/new-console-template for more information

Console.WriteLine("Please pass me a seed(integer)");
var seed = Console.ReadLine();
Random randomGenerator = new Random(int.Parse(seed!));
Console.WriteLine($"""
                   Three numbers between 0 and 5:
                   {randomGenerator.Next(0,5)},
                   {randomGenerator.Next(0,5)},
                   {randomGenerator.Next(0,5)}, 
                   """);
Console.WriteLine($"""
                   Three numbers between 0 and 0.5:
                   {randomGenerator.NextDouble()*0.5},
                   {randomGenerator.NextDouble()*0.5},
                   {randomGenerator.NextDouble()*0.5},
                   """);
Console.WriteLine($"""
                   Three numbers between 0.2 and 0.7:
                   {randomGenerator.NextDouble()*(0.7-0.2)+0.2},
                   {randomGenerator.NextDouble()*(0.7-0.2)+0.2},
                   {randomGenerator.NextDouble()*(0.7-0.2)+0.2},
                   """);
Console.WriteLine("Give me a crit chance between 0,0 and 1,0)");
var critChance = Console.ReadLine();

for (var i = 0; i < 3; i++)
{
    if (randomGenerator.NextDouble() > double.Parse(critChance!))
    {
        Console.WriteLine("No Crit");
    }
    else
    {
        Console.WriteLine("Crit");
    }
}

