// See https://aka.ms/new-console-template for more information

var rng = new Random();
DifficultySelection:
var maxValue = 0;
Console.WriteLine("""
                  Welcome to the Number Guessing Game!
                  Select a difficulty:
                  1 - Easy (1-50)
                  2 - Normal (1-100)
                  3 - Hard (1-150)
                  """);

if (int.TryParse(Console.ReadLine(), out var selectedDifficulty))
{
    switch (selectedDifficulty)
    {
        case 1:
            maxValue = 50;
            break;
        case 2:
            maxValue = 100;
            break;
        case 3:
            maxValue = 150;
            break;
        default:
            Console.WriteLine("Invalid Input");
            goto DifficultySelection;
    }
}
else
{
    Console.WriteLine("Invalid Input");
    goto DifficultySelection;
}

var aiChoice = rng.Next(1, maxValue +1);
Console.WriteLine($"I have picked a number (1-{maxValue}), now it's your turn to guess!!!");
var numberOfTries = 0;
var maxTries = 10;

GameStart:
Console.WriteLine($"You have {maxTries - numberOfTries} tries left");
var userInput = Console.ReadLine();
if (!int.TryParse(userInput, out var userChoice))
{
    Console.WriteLine("Invalid Input");
    goto GameStart;
}

if (numberOfTries == maxTries)
{
    Console.WriteLine($"You lost, you have no more tries left! The number was {aiChoice}");
    goto CloseGame;
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

CloseGame:
Environment.Exit(0);