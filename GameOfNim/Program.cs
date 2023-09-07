// See https://aka.ms/new-console-template for more information

var numberOfMatches = 24;
var isPlayerTurn = true;
var rng = new Random();
Console.WriteLine("Welcome to Nim");
GameStart:
var matchesToShow = Enumerable.Repeat<char>('|', numberOfMatches).ToList<char>();
Console.WriteLine($"{string.Join(separator: "", values: matchesToShow)} ({numberOfMatches})");
if (isPlayerTurn)
{
    goto PlayerTurn;
}


AITurn:

Console.WriteLine("AI's turn");
numberOfMatches -= rng.Next(1,4);
goto CheckVictory;


PlayerTurn:
Console.WriteLine("How many matches do you want to draw?");
if (!int.TryParse(Console.ReadLine(), out var playerDraw) || playerDraw > 3 || playerDraw < 0)
{
    Console.WriteLine("Invalid Input");
    goto GameStart;
}

numberOfMatches -= playerDraw;


CheckVictory:
if (numberOfMatches <= 1)
{
    Console.WriteLine(isPlayerTurn ? "You Won!!":"You Lost");
}
else
{
    isPlayerTurn = !isPlayerTurn;
    goto GameStart;
}