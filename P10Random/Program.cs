// See https://aka.ms/new-console-template for more information

/*
Console.WriteLine("Please pass me a seed(integer)");
var seed = Console.ReadLine();
Random randomGenerator = new Random(int.Parse(seed!));
Console.WriteLine($"""
                   Three numbers between 0 and 5:
                   {randomGenerator.Next(5)},
                   {randomGenerator.Next(5)},
                   {randomGenerator.Next(5)},
                   """);
Console.WriteLine($"""
                   Three numbers between 0 and 0.5:
                   {randomGenerator.NextDouble() * 0.5},
                   {randomGenerator.NextDouble() * 0.5},
                   {randomGenerator.NextDouble() * 0.5},
                   """);
Console.WriteLine($"""
                   Three numbers between 0.2 and 0.7:
                   {randomGenerator.NextDouble() * (0.7 - 0.2) + 0.2},
                   {randomGenerator.NextDouble() * (0.7 - 0.2) + 0.2},
                   {randomGenerator.NextDouble() * (0.7 - 0.2) + 0.2},
                   """);
Console.WriteLine("Give me a crit chance between 0,0 (0%) and 1,0 (100%))");
var critChance = double.Parse(Console.ReadLine()!);

for (var i = 0; i < 5; i++)
{
    if (randomGenerator.NextDouble() < critChance)
    {
        Console.WriteLine("Crit");
    }
    else
    {
        Console.WriteLine("No Crit");
    }
}
*/

/*
var xCoordinate = Random.Shared.Next(0, 101);
var yCoordinate = Random.Shared.Next(0, 101);
Console.WriteLine($"The Enemy is at x:{xCoordinate} y:{yCoordinate}");
*/
/*
var one = (byte) Random.Shared.Next(33, 127);
var two = (byte) Random.Shared.Next(33, 127);
var three = (byte) Random.Shared.Next(33, 127);
var four = (byte) Random.Shared.Next(33, 127);
var five = (byte) Random.Shared.Next(33, 127);
var six = (byte) Random.Shared.Next(33, 127);
var x = System.Text.Encoding.ASCII.GetChars(new byte[]{one, two, three, four, five, six});
Console.WriteLine(x);
*/
/*
Console.WriteLine("Are you ready?");
Console.WriteLine(Random.Shared.NextDouble() < 0.1 ? "You found the secret message, YAAAAAAR!!!" : "Nope, Try again");
*/

var potion = "a Potion";
var sword = "a Sword";
var shield = "a Shield";
var mushrooms = "some Mushrooms";
var bones = "a couple of Bones";
var dropChance = Random.Shared.NextDouble();
var droppedItem = "Nothing, sorry";

if (dropChance < 0.2)
{
    droppedItem = potion;
}else if (dropChance < 0.3)
{
    droppedItem = sword;
}else if (dropChance < 0.5)
{
    droppedItem = shield;
}else if (dropChance < 0.7)
{
    droppedItem = mushrooms;
}else if (dropChance < 0.9)
{
    droppedItem = bones;
}

Console.WriteLine($"You got {droppedItem}");
