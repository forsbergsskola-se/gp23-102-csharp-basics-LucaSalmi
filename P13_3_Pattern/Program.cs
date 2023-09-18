// See https://aka.ms/new-console-template for more information

Console.WriteLine("I can create a nice pattern for you, give me a number");
if (!int.TryParse(Console.ReadLine(), out var size))
{
    Console.WriteLine("Invalid Input");
}

var currentRow = 1;
DrawSymbol:
var symbolCounter = 0;
if (currentRow <= size)
{
    innerLoop:
    if (symbolCounter < size)
    {
        symbolCounter++;
        if (currentRow % 2 == 0)
        {
            Console.Write("-#");
        }
        else
        {
            Console.Write("#-");
        }
        goto innerLoop;
    }

    currentRow++;
    Console.WriteLine();
    goto DrawSymbol;
}