// See https://aka.ms/new-console-template for more information

AppStart:
Console.WriteLine("""
                  Welcome to the P11 Exercises!!
                  Choose an application:
                  1 - Grades
                  2 - MinMax
                  3 - Characters
                  4 - Calculator
                  5 - Even Or Odd
                  """);
var userInput = Console.ReadLine();
if (!int.TryParse(userInput, out var userChoice))
{
    Console.WriteLine("Invalid Input");
}

switch (userChoice)
{
    case 1:
        goto Grades;
    case 2:
        goto MinMax;
    case 3:
        goto Characters;
    case 4:
        goto Calculator;
    case 5:
        goto EverOrOdd;
}

Grades:
Console.WriteLine("""
                  Welcome to the grades calculator!
                  Enter your points
                  """);
var points = int.Parse(Console.ReadLine()!);
var letterGrade = points >= 90 ? 'A' : points >= 80 ? 'B' : points >= 70 ? 'C' : points >= 60 ? 'D' : 'F';
Console.WriteLine($"Your grade is {letterGrade}");
goto AppStart;


MinMax:
Console.WriteLine("""
                  Welcome to MinMax!
                  Enter the first number
                  """);
var minMaxValue1 = float.Parse(Console.ReadLine()!);
Console.WriteLine("Enter the second Number");
var minMaxValue2 = float.Parse(Console.ReadLine()!);
Console.WriteLine("Enter the third Number");
var minMaxValue3 = float.Parse(Console.ReadLine()!);
var highest = minMaxValue1 >= minMaxValue2 ? minMaxValue1 : minMaxValue2;
highest = highest >= minMaxValue3 ? highest : minMaxValue3;
var lowest = minMaxValue1 <= minMaxValue2 ? minMaxValue1 : minMaxValue2;
lowest = lowest <= minMaxValue3 ? lowest : minMaxValue3;
Console.WriteLine($"The highest is {highest} and the lowest is {lowest}");
goto AppStart;


Characters:
Console.WriteLine("""
                  Welcome to Character!
                  Enter a letter or a number
                  """);
var charInput = Console.ReadLine()!.ToCharArray()[0];
var message = char.IsDigit(charInput)
    ? "This is a digit"
    : charInput == 'a' || charInput == 'e' || charInput == 'i' || charInput == 'o' || charInput == 'u' ||
      charInput == 'A' || charInput == 'E' || charInput == 'I' || charInput == 'O' || charInput == 'U'
        ? "This is a vowel"
        : "This is a consonant";
Console.WriteLine(message);
goto AppStart;


Calculator:
Console.WriteLine("""
                  Welcome to Calculator!
                  Enter the left operand:
                  """);
var firstOperand = float.Parse(Console.ReadLine()!);
Console.WriteLine("Enter the operation symbol (+,-,*,/)");
var operationSymbol = Console.ReadLine()!.ToCharArray()[0];
Console.WriteLine("Enter the right operand:");
var secondOperand = float.Parse(Console.ReadLine()!);
var operationResult = operationSymbol == '+'
    ? $"{firstOperand} + {secondOperand} = {firstOperand + secondOperand}"
    : operationSymbol == '-'
        ? $"{firstOperand} - {secondOperand} = {firstOperand - secondOperand}"
        : operationSymbol == '*'
            ? $"{firstOperand} * {secondOperand} = {firstOperand * secondOperand}"
            : operationSymbol == '/'
                ? $"{firstOperand} / {secondOperand} = {firstOperand / secondOperand}"
                : "Invalid Input";

// Alternative Solution
/*
var operationResult = operationSymbol switch
{
    '+' => $"{firstOperand} + {secondOperand} = {firstOperand + secondOperand}",
    '-' => $"{firstOperand} - {secondOperand} = {firstOperand - secondOperand}",
    '*' => $"{firstOperand} * {secondOperand} = {firstOperand * secondOperand}",
    '/' => $"{firstOperand} / {secondOperand} = {firstOperand / secondOperand}",
    _ => "Invalid Input"
};
 */

Console.WriteLine(operationResult);
goto AppStart;


EverOrOdd:
Console.WriteLine("""
                  Welcome to Even Or Odd!
                  Enter a number:
                  """);
var evenOrOddInput = float.Parse(Console.ReadLine()!);
Console.WriteLine(evenOrOddInput % 2 == 0 ? "This is an even number" : "This is an odd number");
goto AppStart;