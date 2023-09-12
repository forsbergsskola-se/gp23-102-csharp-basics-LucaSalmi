// See https://aka.ms/new-console-template for more information


class Battleship
{
    static void Main(string[] args)
    {
         Console.WriteLine("Welcome to Battleship");
         Battleship.DrawMap();
    }

    static void DrawMap()
    {
        char[] horizontalCoordinates = {'a','b','c','d','e','f','g','h'};
        char[] verticalCoordinates = {'1','2','3','4','5','6','7','8'};
        Console.WriteLine($"{string.Join(separator: " ", values: horizontalCoordinates)}");
        foreach (var t in verticalCoordinates)
        {
            Console.WriteLine(t);
        }
    }
}







class Ship
{
    public int length;
    public string position;

    public Ship(int length, string position)
    {
        this.length = length;
        this.position = position;
    }
}