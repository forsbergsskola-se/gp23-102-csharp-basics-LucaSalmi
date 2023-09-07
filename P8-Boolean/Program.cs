// See https://aka.ms/new-console-template for more information

Console.WriteLine("Write your Age:");
var ageInput = Console.ReadLine();
if (int.TryParse(ageInput, out var age))
{
  var isChild = age < 13;
  var isTeenager = age is >= 13 and <= 19;
  var isAdult = age > 19;
    
    Console.WriteLine($"You are a Child: {isChild}");
    Console.WriteLine($"You are a Teenager: {isTeenager}");
    Console.WriteLine($"You are an Adult: {isAdult}");
}
else
{
    Console.WriteLine("Invalid Input");
}