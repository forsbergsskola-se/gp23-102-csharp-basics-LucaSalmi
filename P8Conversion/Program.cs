// See https://aka.ms/new-console-template for more information

using System.Globalization;

Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

Console.WriteLine("Write a Number");
string? userInput = Console.ReadLine()!;
double convertedToDouble = Convert.ToDouble(userInput);
Console.WriteLine($"double from string {convertedToDouble}");
int convertedToInt = (int)convertedToDouble;
Console.WriteLine($"int from double {convertedToInt}");
int number = Convert.ToInt32(userInput);
Console.WriteLine($"int from string {number}");