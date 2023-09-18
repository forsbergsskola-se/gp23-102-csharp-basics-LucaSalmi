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
        };

    static void Main(string[] args)
    {
        SetupBoard();
        GameLoop:        
        PlayerAttack();
        PrintMap(false);
        AiAttack();
        PrintMap(true);
        goto GameLoop;
    }

    static void PlayerAttack()
    {
        Console.WriteLine("where do you want to attack?");
        var attackCoordinates = Console.ReadLine()!.ToCharArray();
        int row = Coordinate[attackCoordinates.First()];
        int col = Coordinate.Values.ElementAt((int)char.GetNumericValue(attackCoordinates[1])-1);
        var lastAttackPosition = new Position();
        lastAttackPosition.x = row;
        lastAttackPosition.y = col;
        var hasHit = Ships.EnemyShipsPosition.Any(enemyPosition =>
            enemyPosition.x == lastAttackPosition.x && enemyPosition.y == lastAttackPosition.y);
        Console.WriteLine(hasHit ? "HIT" : "WATER");
        if (!hasHit)
        {
            Ships.PlayerFirePositions.Add(lastAttackPosition);
        }
        else
        {
            Ships.EnemyShipsPosition
                .First(position => position.x == lastAttackPosition.x && position.y == lastAttackPosition.y).isHit = true;
        }
    }

    static void AiAttack()
    {
        Console.WriteLine("Ai turn");
        var attackCoordinates = new Position();
        attackCoordinates.x = Random.Shared.Next(1, 10);
        attackCoordinates.y = Random.Shared.Next(1, 10);
        var hasHit = Ships.PlayerShipsPosition.Any(playerPosition =>
            playerPosition.x == attackCoordinates.x && playerPosition.y == attackCoordinates.y);
        Console.WriteLine(hasHit ? "ai HIT" : " ai WATER");
        if (!hasHit)
        {
            Ships.EnemyFirePositions.Add(attackCoordinates);
        }
        else
        {
            Ships.PlayerShipsPosition
                .First(position => position.x == attackCoordinates.x && position.y == attackCoordinates.y).isHit = true;
        }
    }

    static void SetupBoard()
    {
        Console.WriteLine("Welcome to Battleship");
        Battleship.PrintMap(true);
        Ships.PlayerShipsPosition.AddRange(PlaceShip(5));
        Battleship.PrintMap(true);
        Ships.PlayerShipsPosition.AddRange(PlaceShip(4));
        Battleship.PrintMap(true);
        Ships.PlayerShipsPosition.AddRange(PlaceShip(3));
        Battleship.PrintMap(true);
        Ships.PlayerShipsPosition.AddRange(PlaceShip(2));
        Battleship.PrintMap(true);
        Ships.PlayerShipsPosition.AddRange(PlaceShip(2));
        Battleship.PrintMap(true);
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
        int col = Coordinate.Values.ElementAt((int)char.GetNumericValue(position[1]) - 1);


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
                 from existingPosition in Ships.PlayerShipsPosition.Where(existingPosition =>
                     existingPosition.x == newPosition.x && existingPosition.y == newPosition.y)
                 select newPosition)
        {
            Console.WriteLine("Position already taken");
            goto placingShip;
        }

        return positions;
    }

    static void PrintMap(bool isPlayerMap)
    {
        
        Console.ForegroundColor = isPlayerMap ? ConsoleColor.DarkYellow : ConsoleColor.DarkCyan;
        Console.Write("[ ]");
        for (int i = 1; i < 10; i++)
            Console.Write("[" + i + "]");
        
        Console.WriteLine();
        List<Position> sortedPlayerShipsPositions = Ships.PlayerShipsPosition.OrderBy(horizontal => horizontal.x)
            .ThenBy(vertical => vertical.y).ToList();

        List<Position> sortedEnemyShipsPositions = Ships.EnemyShipsPosition.OrderBy(horizontal => horizontal.x)
            .ThenBy(vertical => vertical.y).ToList();

        var sortedListToUse = isPlayerMap ? sortedPlayerShipsPositions : sortedEnemyShipsPositions;

        var row = 'A';
        var columnMax = 10;
        try
        {
            for (var x = 1; x < columnMax; x++)
            {
                for (var y = 1; y < columnMax; y++)
                {
                    var keepGoing = true;

                    if (y == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("[" + row + "]");
                        row++;
                    }

                    if (sortedListToUse.Count != 0 &&
                        sortedListToUse.Exists(shipPos => shipPos.x == x && shipPos.y == y && shipPos.isHit))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[X]");

                        keepGoing = false;
                    }


                    if (keepGoing && sortedListToUse.Count != 0 &&
                        sortedListToUse.Exists(shipPos => shipPos.x == x && shipPos.y == y))

                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("[O]");
                        keepGoing = false;
                    }

                    if (keepGoing)
                    {
                        var firePositionsToUse = isPlayerMap ? Ships.EnemyFirePositions : Ships.PlayerFirePositions;
                        if (firePositionsToUse.Exists(firePos => firePos.x == x && firePos.y == y))
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("[+]");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("[~]");
                        }
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
}

class Position
{
    public int x { get; set; } = -1;
    public int y { get; set; } = -1;
    public bool isHit { get; set; } = false;
}


class Ships
{
    public static List<Position> PlayerShipsPosition { get; set; } = new List<Position>();
    public static List<Position> EnemyShipsPosition { get; set; } = new List<Position>();
    public static List<Position> PlayerFirePositions { get; set; } = new List<Position>();
    public static List<Position> EnemyFirePositions { get; set; } = new List<Position>();

    public static List<Position> GeneratePositionRandomly(int size)
    {
        List<Position> positions = new List<Position>();

        int direction = Random.Shared.Next(1, size); //odd for horizontal and even for vertical
        //pick row and column
        int row = Random.Shared.Next(1, 10);
        int col = Random.Shared.Next(1, 10);

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