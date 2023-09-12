// See https://aka.ms/new-console-template for more information

var numberOfMatches = 24;
var isPlayerOneTurn = true;
bool isHardDifficulty = false;
var isTwoPlayer = false;
var rng = new Random();

GameSetup:
Console.WriteLine("""
                  Welcome to the game of Nim
                  Choose the mode:
                  1 - Easy
                  2 - Hard
                  3 - Two Players
                  """);
if (int.TryParse(Console.ReadLine(), out var selectedMode))
{
    switch (selectedMode)
    {
        case 1:
            break;
        case 2:
            isHardDifficulty = true;
            break;
        case 3:
            isTwoPlayer = true;
            break;
        default:
            Console.WriteLine("Invalid Input");
            goto GameSetup;
    }
}
else
{
    Console.WriteLine("Invalid Input");
    goto GameSetup;
}

GameStart:
var matchesToShow = Enumerable.Repeat('|', numberOfMatches).ToList();
Console.WriteLine($"{string.Join(separator: "", values: matchesToShow)} ({numberOfMatches})");
if (isPlayerOneTurn || isTwoPlayer)
{
    goto PlayerTurn;
}


AITurn:
Console.WriteLine("AI's turn");
var aiDraw = 0;
if (isHardDifficulty)
{
    for (var i = 1; i <= 3; i++)
    {
        if ((numberOfMatches - i) % 4 <= 1)
        {
            aiDraw = i;
            break;
        }
    }
}
else
{
    aiDraw = rng.Next(1, 4);
}

if (aiDraw == 0)
{
    aiDraw = 1;
}

numberOfMatches -= aiDraw;
Console.WriteLine($"the AI draws {aiDraw} {(numberOfMatches > 1 ? "matches" : "match")}");
goto CheckVictory;


PlayerTurn:
Console.WriteLine(isTwoPlayer
    ? $"How many matches do {(isPlayerOneTurn ? "Player One" : "Player two")} want to draw?"
    : "How many matches do you want to draw?");

if (!int.TryParse(Console.ReadLine(), out var playerDraw) || playerDraw > 3 || playerDraw < 0)
{
    Console.WriteLine("Invalid Input");
    goto GameStart;
}

numberOfMatches -= playerDraw;
Console.WriteLine($"You drew {playerDraw} {(numberOfMatches > 1 ? "matches" : "match")}");


CheckVictory:
if (numberOfMatches <= 0)
{
    if (isTwoPlayer)
    {
        Console.WriteLine(isPlayerOneTurn ? "Player Two Won" : "Player One Won");
    }
    else
    {
        Console.WriteLine(isPlayerOneTurn ? "You Lost!!" : "You Won");
    }
}
else
{
    isPlayerOneTurn = !isPlayerOneTurn;
    goto GameStart;
}