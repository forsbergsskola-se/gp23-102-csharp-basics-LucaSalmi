// See https://aka.ms/new-console-template for more information


class Battleship
{
    public static Dictionary<char, int> Coordinate =
        new Dictionary<char, int>
        {
            { 'a', 1 },
            { 'b', 2 },
            { 'c', 3 },
            { 'd', 4 },
            { 'e', 5 },
            { 'f', 6 },
            { 'g', 7 },
            { 'h', 8 },
            { 'i', 9 },
            { 'j', 10 }
        };

    static void Main(string[] args)
    {
        SetupBoard();
        Console.WriteLine($"{Ships.EnemyShipsPosition.First().x} {Ships.EnemyShipsPosition.First().y}");
        PlayerAttack();
        PrintMap();
    }

    static void PlayerAttack()
    {
        Console.WriteLine("where do you want to attack?");
        var attackCoordinates = Console.ReadLine()!.ToCharArray();
        int row = Coordinate[attackCoordinates.First()];
        int col = Coordinate.Values.ElementAt((int)char.GetNumericValue(attackCoordinates[1]));
        var hasHit = Ships.EnemyShipsPosition.Any(enemyPosition => enemyPosition.x == row && enemyPosition.y == col);
        Console.WriteLine(hasHit ? "HIT" : "WATER");
        
    }

    static void SetupBoard()
    {
        Console.WriteLine("Welcome to Battleship");
        Battleship.PrintMap();
        Ships.AllShipsPosition.AddRange(PlaceShip(5));
        Battleship.PrintMap();
        Ships.AllShipsPosition.AddRange(PlaceShip(4));
        Battleship.PrintMap();
        Ships.AllShipsPosition.AddRange(PlaceShip(3));
        Battleship.PrintMap();
        Ships.AllShipsPosition.AddRange(PlaceShip(2));
        Battleship.PrintMap();
        Ships.AllShipsPosition.AddRange(PlaceShip(2));
        Battleship.PrintMap();
        Ships.EnemyShipsPosition.AddRange(Ships.GeneratePositionRandomly(5));
        Ships.EnemyShipsPosition.AddRange(Ships.GeneratePositionRandomly(4));
        Ships.EnemyShipsPosition.AddRange(Ships.GeneratePositionRandomly(3));
        Ships.EnemyShipsPosition.AddRange(Ships.GeneratePositionRandomly(2));
        Ships.EnemyShipsPosition.AddRange(Ships.GeneratePositionRandomly(2));
    }

    static List<Position> PlaceShip(int shipLength)
    {
        placingShip:
        Console.WriteLine($"Where do you want to place your {shipLength} size ship? (format: A1)");
        var position = Console.ReadLine()!.ToCharArray();
        Console.WriteLine("Horizontal (y/n)");
        var shipAlignment = Console.ReadLine()!.ToCharArray();

        List<Position> positions = new List<Position>();

        int direction = shipAlignment.First() == 'y' ? 0 : 1;
        int row = Coordinate[position.First()];
        int col = Coordinate.Values.ElementAt((int)char.GetNumericValue(position[1])-1);


        if (direction % 2 != 0)
        {
            if (row - shipLength > 0)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    Position pos = new Position();
                    pos.x = row - i;
                    pos.y = col;
                    positions.Add(pos);
                }
            }
            else
            {
                for (int i = 0; i < shipLength; i++)
                {
                    Position pos = new Position();
                    pos.x = row + i;
                    pos.y = col;
                    positions.Add(pos);
                }
            }
        }
        else
        {
            if (col - shipLength > 0)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    Position pos = new Position();
                    pos.x = row;
                    pos.y = col - i;
                    positions.Add(pos);
                }
            }
            else
            {
                for (int i = 0; i < shipLength; i++)
                {
                    Position pos = new Position();
                    pos.x = row;
                    pos.y = col + i;
                    positions.Add(pos);
                }
            }
        }

        foreach (var newPosition in from newPosition in positions
                 from existingPosition in Ships.AllShipsPosition.Where(existingPosition =>
                     existingPosition.x == newPosition.x && existingPosition.y == newPosition.y)
                 select newPosition)
        {
            Console.WriteLine("Position already taken");
            goto placingShip;
        }

        return positions;
    }

    static void PrintMap()
    {
        PrintHeader();
        Console.WriteLine();
        List<Position> sortedShipsPositions = Ships.AllShipsPosition.OrderBy(horizontal => horizontal.x)
            .ThenBy(vertical => vertical.y).ToList();

        var row = 'A';
        try
        {
            for (var x = 1; x < 11; x++)
            {
                for (var y = 1; y < 11; y++)
                {
                    var keepGoing = true;

                    if (y == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("[" + row + "]");
                        row++;
                    }

                    if (Ships.AllShipsPosition.Count != 0 &&
                        Ships.AllShipsPosition.Exists(shipPos => shipPos.x == x && shipPos.y == y && shipPos.isHit))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[X]");

                        keepGoing = false;
                    }


                    if (keepGoing && sortedShipsPositions.Count != 0 &&
                        Ships.AllShipsPosition.Exists(shipPos => shipPos.x == x && shipPos.y == y))

                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("[O]");
                        keepGoing = false;
                    }

                    if (keepGoing)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("[~]");
                    }
                }

                Console.WriteLine();
            }
        }
        catch (Exception e)
        {
            string error = e.Message.ToString();
        }
    }

    static void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("[ ]");
        for (int i = 1; i < 11; i++)
            Console.Write("[" + i + "]");
    }
}

class Position
{
    public int x { get; set; } = -1;
    public int y { get; set; } = -1;
    public bool isHit { get; set; } = false;
}


class Ships
{
    public static List<Position> AllShipsPosition { get; set; } = new List<Position>();
    public static List<Position> EnemyShipsPosition { get; set; } = new List<Position>();
    public List<Position> FirePositions { get; set; } = new List<Position>();

    public static List<Position> GeneratePositionRandomly(int size)
    {
        List<Position> positions = new List<Position>();

        int direction = Random.Shared.Next(1, size); //odd for horizontal and even for vertical
        //pick row and column
        int row = Random.Shared.Next(1, 11);
        int col = Random.Shared.Next(1, 11);

        if (direction % 2 != 0)
        {
            //left first, then right
            if (row - size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    Position pos = new Position();
                    pos.x = row - i;
                    pos.y = col;
                    positions.Add(pos);
                }
            }
            else // row
            {
                for (int i = 0; i < size; i++)
                {
                    Position pos = new Position();
                    pos.x = row + i;
                    pos.y = col;
                    positions.Add(pos);
                }
            }
        }
        else
        {
            //top first, then bottom
            if (col - size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    Position pos = new Position();
                    pos.x = row;
                    pos.y = col - i;
                    positions.Add(pos);
                }
            }
            else // row
            {
                for (int i = 0; i < size; i++)
                {
                    Position pos = new Position();
                    pos.x = row;
                    pos.y = col + i;
                    positions.Add(pos);
                }
            }
        }

        return positions;
    }
}