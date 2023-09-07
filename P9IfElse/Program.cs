// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information

Console.WriteLine("Write your Age:");
var ageInput = Console.ReadLine();
if (int.TryParse(ageInput, out var age))
{
    switch (age)
    {
        case < 13:
            Console.WriteLine($"You are a Child");
            break;
        case < 19:
            Console.WriteLine($"You are a Teenager");
            break;
        default:
            Console.WriteLine($"You are an Adult");
            break;
    }

    Console.WriteLine("Give me another number");
    var secondInput = Console.ReadLine()!;
    if (int.TryParse(secondInput, out var secondValue))
    {
        if (secondValue < age)
        {
            Console.WriteLine("This number is lower then your age");
        }
        else if (secondValue > age)
        {
            Console.WriteLine("This number is higher then your age");
        }
        else
        {
            Console.WriteLine("This number is the same as your age");
        }

        Console.WriteLine(secondValue % 2 == 1
            ? "The number is odd"
            : "The number is even");
    }
}
else
{
    Console.WriteLine("Invalid Input");
}