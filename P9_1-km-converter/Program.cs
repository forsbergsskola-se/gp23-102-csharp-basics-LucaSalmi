// See https://aka.ms/new-console-template for more information

AppStart:
Console.WriteLine("""
                  Welcome to the math application!!
                  Choose an application:
                  1 - km/h to m/s
                  2 - minutes to seconds
                  3 - reminder of division
                  4 - Area of circle
                  5 - negation of number
                  6 - division
                  7 - multiplication
                  8 - BMI Calculator
                  9 - hypotenuse of a triangle
                  """);
var userInput = Console.ReadLine();
if (!int.TryParse(userInput, out var userChoice))
{
    Console.WriteLine("Invalid Input");
}

switch (userChoice)
{
    case 1:
        goto KilometerConverter;
    case 2:
        goto SecondsToMinutesConverter;
    case 3:
        goto reminderOfDivision;
    case 4:
        goto AreaOfCircle;
    case 5:
        goto NegateValue;
    case 6:
        goto Division;
    case 7:
        goto Multiplication;
    case 8:
        goto BmiCalculator;
    case 9:
        goto HypotenuseOfTriangle;
}

// km/h to m/s converter
KilometerConverter:
Console.WriteLine("""
                  Welcome to the km/h to m/s converter!
                  Enter a value in km/h
                  """);
var kmInput = Console.ReadLine();
var kmHValue = float.Parse(kmInput!);
var milesPerSecValue = (kmHValue / 3600) * 1000;
Console.WriteLine($"You are going at {milesPerSecValue} m/s");
goto AppStart;

// second to minutes converter
SecondsToMinutesConverter:
Console.WriteLine("""
                  Welcome to the minutes to seconds converter!
                  Enter a value:
                  """);
var secondsInput = Console.ReadLine();
var minutes = int.Parse(secondsInput!);
var seconds = minutes * 60;
Console.WriteLine($"{minutes} minutes is {seconds} seconds in total");
goto AppStart;

reminderOfDivision:
Console.WriteLine("""
                  Welcome to the reminder of division calculator!
                  Enter the first value:
                  """);
var firstInput = Console.ReadLine();
Console.WriteLine("Enter another value");
var secondInput = Console.ReadLine();
var divider = int.Parse(firstInput!);
var dividend = int.Parse(secondInput!);
Console.WriteLine($"The reminder is {divider % dividend}");
goto AppStart;

AreaOfCircle:
Console.WriteLine("""
                  Welcome to the area of circle calculator!
                  Enter the radius of the circle:
                  """);
var radiusInput = Console.ReadLine();
var radius = double.Parse(radiusInput!);
var area = Math.PI * (radius * radius);
Console.WriteLine($"The area is {area}");
goto AppStart;

NegateValue:
Console.WriteLine("""
                  Welcome to the negation app!
                  Enter a value:
                  """);
var valueInput = Console.ReadLine();
var value = double.Parse(valueInput!);
Console.WriteLine($"The negative is {-value}");
goto AppStart;

Division:
Console.WriteLine("""
                  Welcome to the division calculator!
                  Enter the first value:
                  """);
var divisionInput1 = Console.ReadLine();
Console.WriteLine("Enter another value");
var divisionInput2 = Console.ReadLine();
var divisionValue1 = double.Parse(divisionInput1!);
var divisionValue2 = double.Parse(divisionInput2!);
Console.WriteLine($"The result is {divisionValue1 / divisionValue2}");
goto AppStart;

Multiplication:
Console.WriteLine("""
                  Welcome to the multiplication calculator!
                  Enter the first value:
                  """);
var multiplicationInput1 = Console.ReadLine();
Console.WriteLine("Enter another value");
var multiplicationInput2 = Console.ReadLine();
var multiplicationValue1 = int.Parse(multiplicationInput1!);
var multiplicationValue2 = int.Parse(multiplicationInput2!);
Console.WriteLine($"The result is {multiplicationValue1 * multiplicationValue2}");
goto AppStart;

BmiCalculator:
Console.WriteLine("""
                  Welcome to the BMI calculator!
                  Enter your height in meters:
                  """);
var heigthInput = Console.ReadLine();
Console.WriteLine("Enter your weight in kg");
var weightInput = Console.ReadLine();
var height = double.Parse(heigthInput!);
var weight = double.Parse(weightInput!);
var bmi = (weight / (height * height)) * 10000;
Console.WriteLine($"Your BMI is: {bmi:F1}");
goto AppStart;

HypotenuseOfTriangle:
Console.WriteLine("""
                  Welcome to the multiplication calculator!
                  Enter the length of the first side:
                  """);
var firstSideInput = Console.ReadLine();
Console.WriteLine("Enter the length of the second side");
var secondSideInput = Console.ReadLine();
var firstSideValue = double.Parse(firstSideInput!);
var secondSideValue = double.Parse(secondSideInput!);
var hypotenuse = (firstSideValue * firstSideValue) + (secondSideValue * secondSideValue);
Console.WriteLine($"The hypotenuse is {Math.Sqrt(hypotenuse)}");
goto AppStart;