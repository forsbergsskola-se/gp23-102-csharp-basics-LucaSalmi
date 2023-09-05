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
        case > 19:
            Console.WriteLine($"You are an Adult");
            break;
        default:
            Console.WriteLine($"You are a Teenager");
            break;
    }
    
    Console.WriteLine("Give me another number");
    var secondInput = Console.ReadLine()!;
    if (int.TryParse(secondInput, out var secondValue))
    {
        Console.WriteLine(secondValue > age
            ? "This number is higher then your age"
            : "This number is lower then your age");
        
        Console.WriteLine(secondValue % 2 == 1
            ? "The number is odd"
            : "The number is even");
    }
}
else
{
    Console.WriteLine("Invalid Input");
}