// See https://aka.ms/new-console-template for more information

using System.Globalization;

Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

Console.WriteLine("Write a Number");
string? userInput = Console.ReadLine();
if (userInput == null)
{
    Console.WriteLine("Invalid Input");
}
else
{
   double convertedToDouble = Convert.ToDouble(userInput);
   Console.WriteLine($"double from string {convertedToDouble}");
   int convertedToInt = (int)convertedToDouble;
   Console.WriteLine($"int from double {convertedToInt}");
   int number = int.Parse(userInput);
   Console.WriteLine($"int from string {number}");

}