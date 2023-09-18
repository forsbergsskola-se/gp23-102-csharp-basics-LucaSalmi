// See https://aka.ms/new-console-template for more information

Console.WriteLine("You See a Pyramid, how tall is it?");
if (!int.TryParse(Console.ReadLine()!, out var heigth))
{
    Console.WriteLine("Invalid Input");
}
var rowsCounter = 1;

StartDrawing:
var symbolCounter = rowsCounter -1;
if (heigth >= rowsCounter)
{
    innerLoop:
    if (symbolCounter < heigth)
    {
        symbolCounter++;
        Console.Write("*");
        goto innerLoop;
    }

    rowsCounter++;
    Console.WriteLine();
    goto StartDrawing;
}

