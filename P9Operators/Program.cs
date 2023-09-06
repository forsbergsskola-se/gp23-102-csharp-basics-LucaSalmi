// See https://aka.ms/new-console-template for more information

Console.WriteLine("Write an amount of seconds:");
var userInput = Console.ReadLine();
if (int.TryParse(userInput, out var totalSeconds))
{
    var hours = (totalSeconds / 3600);  // TOT / by number of seconds in a day
    var days = hours / 24;
    hours -= (24 * days);
    var minutes = (totalSeconds % 3600) / 60;  // (TOT reminder of number of seconds in a day) / number of minutes in an hour
    var seconds = totalSeconds % (minutes * 60); // TOT % (minutes * seconds in a minute)
    var daysTotal = totalSeconds / (24 * 3600f); // TOT / (hours in a day * seconds in a day) Float for precision
    
    Console.WriteLine($"""
                       seconds: {seconds}
                       minutes: {minutes},
                       hours: {hours},
                       days: {days},
                       """);
    Console.WriteLine($"{days}.{hours}:{minutes}:{seconds}");
    Console.WriteLine($"In total it's {daysTotal} days");
};