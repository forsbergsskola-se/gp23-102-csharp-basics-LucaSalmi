// See https://aka.ms/new-console-template for more information

// Switch between 0 and 1 inputs
/*
Console.WriteLine("input 0 or 1");
var inputValue = int.Parse(Console.ReadLine()!);
Console.WriteLine($"{1-inputValue}");
*/

Start:
Console.WriteLine("write a number");
var firstValue = int.Parse(Console.ReadLine()!);
Console.WriteLine("write another number");
var secondValue = int.Parse(Console.ReadLine()!);
var output = Math.Abs(firstValue - secondValue) + firstValue;
Console.WriteLine($"The highest is {output}");//highest of the two values
goto Start;

/*
Console.WriteLine("write a number");
var firstValue = int.Parse(Console.ReadLine()!);
Console.WriteLine("write another number");
var secondValue = int.Parse(Console.ReadLine()!);
Console.WriteLine($"First Variable = {firstValue}");
Console.WriteLine($"Second Variable = {secondValue}");
firstValue = Math.Abs(firstValue + secondValue);//32
secondValue = Math.Abs(firstValue - secondValue); // 28
firstValue -= secondValue;
Console.WriteLine($"First Variable after inversion = {firstValue}");
Console.WriteLine($"Second Variable after inversion = {secondValue}");
goto Start;
*/



/*

*/
