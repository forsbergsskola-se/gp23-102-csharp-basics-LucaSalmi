// See https://aka.ms/new-console-template for more information

var numberOfMatches = 24;
var isPlayerTurn = true;
bool isHardDifficulty;
var rng = new Random();

GameSetup:
Console.WriteLine("""
                  Welcome to the game of Nim
                  Choose a difficulty level:
                  1 - Easy
                  2 - Hard
                  """);
if (int.TryParse(Console.ReadLine(), out var difficultySelection) && difficultySelection is <= 2 and >= 1)
{
    isHardDifficulty = difficultySelection is 2;
}
else
{
    Console.WriteLine("Invalid Input");
    goto GameSetup;
}

GameStart:
var matchesToShow = Enumerable.Repeat('|', numberOfMatches).ToList();
Console.WriteLine($"{string.Join(separator: "", values: matchesToShow)} ({numberOfMatches})");
if (isPlayerTurn)
{
    goto PlayerTurn;
}


AITurn:
Console.WriteLine("AI's turn");
var aiDraw = 0;
if (isHardDifficulty)
{
    for (int i = 1; i <= 3; i++)
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
Console.WriteLine($"the AI draws {aiDraw} matches");
goto CheckVictory;


PlayerTurn:
Console.WriteLine("How many matches do you want to draw?");
if (!int.TryParse(Console.ReadLine(), out var playerDraw) || playerDraw > 3 || playerDraw < 0)
{
    Console.WriteLine("Invalid Input");
    goto GameStart;
}

numberOfMatches -= playerDraw;
Console.WriteLine($"You drew {playerDraw} matches");


CheckVictory:
if (numberOfMatches <= 1)
{
    Console.WriteLine(isPlayerTurn ? "You Won!!" : "You Lost");
}
else
{
    isPlayerTurn = !isPlayerTurn;
    goto GameStart;
}