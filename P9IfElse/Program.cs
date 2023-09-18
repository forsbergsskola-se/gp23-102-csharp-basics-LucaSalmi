// See https://aka.ms/new-console-template for more information

Console.WriteLine("Write your Age:");
var ageInput = Console.ReadLine();
if (int.TryParse(ageInput, out var age))
{
    string response = age < 13 ? "You are a Child" : age < 19 ? "You are a Teenager" : "You are an Adult";
    Console.WriteLine(response);

    Console.WriteLine("Give me another number");
    var secondInput = Console.ReadLine()!;
    if (int.TryParse(secondInput, out var secondValue))
    {
        var maxNumber = secondValue < age ? age : secondValue;
        Console.WriteLine($"The maximum is {maxNumber}");
        /*
         string biggerOrMessage = secondValue < age ? "This number is lower then your age" :
         secondValue > age ? "This number is higher then your age" : "This number is the same as your age";
         Console.WriteLine(biggerOrMessage);
         */
        Console.WriteLine(maxNumber % 2 == 1
            ? "The number is odd"
            : "The number is even");
    }
}
else
{
    Console.WriteLine("Invalid Input");
}