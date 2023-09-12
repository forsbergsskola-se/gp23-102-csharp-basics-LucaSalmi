// See https://aka.ms/new-console-template for more information


class Battleship
{
    public static Ship[] playerOneShips = new Ship[5];

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Battleship");
        Battleship.DrawMap();
        Battleship.PlaceShip(5);
    }

    static void PlaceShip(int shipLength)
    {
        Console.WriteLine($"Where do you want to place your {shipLength} ship?");
        var position = Console.ReadLine()!;
        Console.WriteLine("Horizontal (y/n)");
        var shipAlignment = Console.ReadLine()!.ToCharArray();
        var newShip = new Ship(length: shipLength, position: position);
        newShip.isHorizontal = shipAlignment.First() == 'y' ? true : false;
        Battleship.playerOneShips[^1] = newShip;
    }

    static void DrawMap()
    {
        char[,] coordinates =
            { { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' }, { '1', '2', '3', '4', '5', '6', '7', '8' } };
        var horizontalString = " ";
        for (var i = 0; i < coordinates.Length / 2; i++)
        {
            horizontalString = $"{horizontalString} {coordinates[0, i]}";
        }

        Console.WriteLine(horizontalString);

        for (var i = 0; i < coordinates.Length / 2; i++)
        {
            Console.WriteLine(coordinates[1, i]);
        }
    }
}


class Ship
{
    public int length;
    public string position;
    public bool isHorizontal;

    public Ship(int length, string position)
    {
        this.length = length;
        this.position = position;
    }
}