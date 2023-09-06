// See https://aka.ms/new-console-template for more information

var rng = new Random();
Console.WriteLine("I have picked a number (1-100), now it's your turn to guess!!!");
var aiChoice = rng.Next(1, 101);
var numberOfTries = 0;
const int maxTries = 10;

GameStart:
Console.WriteLine($"You have {maxTries-numberOfTries} tries left");
var userInput = Console.ReadLine();
if (!int.TryParse(userInput, out var userChoice))
{
    Console.WriteLine("Invalid Input");
    goto GameStart;
}

if (numberOfTries == maxTries)
{
    Console.WriteLine($"You lost, you have no more tries left");
    return;
}

if (userChoice < aiChoice)
{
    Console.WriteLine("My number is higher...");
    numberOfTries++;
    goto GameStart;
}
if (userChoice > aiChoice)
{
    Console.WriteLine("My number is lower...");
    numberOfTries++;
    goto GameStart;
}

if (userChoice == aiChoice)
{
    Console.WriteLine($"You won, it only took you {numberOfTries} tries");
    
}