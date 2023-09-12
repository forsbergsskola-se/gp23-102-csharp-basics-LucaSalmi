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
                  10 - minutes and seconds
                  11 - Time Calculator
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
    case 10:
        goto MinutesAndSeconds;
    case 11:
        goto TimeCalculator;
}

// km/h to m/s converter
KilometerConverter:
Console.WriteLine("""
                  Welcome to the km/h to m/s converter!
                  Enter a value in km/h
                  """);
var kmHValue = float.Parse(Console.ReadLine()!);
var milesPerSecValue = (kmHValue / 3600) * 1000;
Console.WriteLine($"You are going at {milesPerSecValue} m/s");
goto AppStart;

// second to minutes converter
SecondsToMinutesConverter:
Console.WriteLine("""
                  Welcome to the minutes to seconds converter!
                  Enter a value:
                  """);
var minutes = int.Parse(Console.ReadLine()!);
var seconds = minutes * 60;
Console.WriteLine($"{minutes} minutes is {seconds} seconds in total");
goto AppStart;

// Remainder of Division
reminderOfDivision:
Console.WriteLine("""
                  Welcome to the reminder of division calculator!
                  Enter the first value:
                  """);
var divider = int.Parse(Console.ReadLine()!);
Console.WriteLine("Enter another value");
var dividend = int.Parse(Console.ReadLine()!);
Console.WriteLine($"The reminder is {divider % dividend}");
goto AppStart;

// Area of circle
AreaOfCircle:
Console.WriteLine("""
                  Welcome to the area of circle calculator!
                  Enter the radius of the circle:
                  """);
var radius = float.Parse(Console.ReadLine()!);
var area = float.Pi * MathF.Pow(radius, 2);
Console.WriteLine($"The area is {area}");
goto AppStart;

// Negate value
NegateValue:
Console.WriteLine("""
                  Welcome to the negation app!
                  Enter a value:
                  """);
var value = double.Parse(Console.ReadLine()!);
Console.WriteLine($"The negative is {-value}");
goto AppStart;

// Division
Division:
Console.WriteLine("""
                  Welcome to the division calculator!
                  Enter the first value:
                  """);
var divisionValue1 = float.Parse(Console.ReadLine()!);
Console.WriteLine("Enter another value");
var divisionValue2 = float.Parse(Console.ReadLine()!);
Console.WriteLine($"The result is {divisionValue1 / divisionValue2}");
goto AppStart;

// Multiplication
Multiplication:
Console.WriteLine("""
                  Welcome to the multiplication calculator!
                  Enter the first value:
                  """);
var multiplicationValue1 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Enter another value");
var multiplicationValue2 = int.Parse(Console.ReadLine()!);
Console.WriteLine($"The result is {multiplicationValue1 * multiplicationValue2}");
goto AppStart;

//BMI calculator
BmiCalculator:
Console.WriteLine("""
                  Welcome to the BMI calculator!
                  Enter your height in meters:
                  """);
var height = double.Parse(Console.ReadLine()!);
Console.WriteLine("Enter your weight in kg");
var weight = double.Parse(Console.ReadLine()!);
var bmi = (weight / Math.Pow(height, 2));
Console.WriteLine($"Your BMI is: {bmi:F1}");
goto AppStart;

// Hypotenuse of Triangle
HypotenuseOfTriangle:
Console.WriteLine("""
                  Welcome to the multiplication calculator!
                  Enter the length of the first side:
                  """);
var firstSideValue = float.Parse(Console.ReadLine()!);
Console.WriteLine("Enter the length of the second side");
var secondSideValue = float.Parse(Console.ReadLine()!);
var hypotenuse = MathF.Pow(firstSideValue, 2) + MathF.Pow(secondSideValue, 2);
Console.WriteLine($"The hypotenuse is {MathF.Sqrt(hypotenuse)}");
goto AppStart;

// Minutes and remaining seconds
MinutesAndSeconds:
Console.WriteLine("""
                  Welcome to the minutes and seconds calculator!
                  Enter an amount of seconds:
                  """);
var totalSecondsValue = int.Parse(Console.ReadLine()!);
var minutesValue = totalSecondsValue / 60;
var remainingSecondsValue = totalSecondsValue % 60;
Console.WriteLine($"The value corresponds to {minutesValue} minutes and {remainingSecondsValue} seconds");
goto AppStart;

TimeCalculator:
Console.WriteLine("Write an amount of seconds:");
var secondsInput = Console.ReadLine();
if (int.TryParse(secondsInput, out var totalSeconds))
{
    var hoursTotal = (totalSeconds / 3600); // TOT / by number of seconds in a day
    var days = hoursTotal / 24;
    hoursTotal -= (24 * days);
    var minutesTotal =
        (totalSeconds % 3600) / 60; // (TOT reminder of number of seconds in a day) / number of minutes in an hour
    var secondsTotal = totalSeconds % (minutesTotal * 60); // TOT % (minutes * seconds in a minute)
    var daysFraction =
        (float)totalSeconds / (24 * 3600); // TOT / (hours in a day * seconds in a day) Float for precision

    Console.WriteLine($"""
                       seconds: {secondsTotal}
                       minutes: {minutesTotal},
                       hours: {hoursTotal},
                       days: {days},
                       """);
    Console.WriteLine($"{days}.{hoursTotal}:{minutesTotal}:{secondsTotal}");
    Console.WriteLine($"In total it's {daysFraction} days");
}
goto AppStart;