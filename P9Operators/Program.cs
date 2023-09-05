// See https://aka.ms/new-console-template for more information

Console.WriteLine("Write an amount of seconds:");
var userInput = Console.ReadLine();
if (int.TryParse(userInput, out var totalSeconds))
{
    var hours = (totalSeconds / 3600);
    var minutes = (totalSeconds % 3600) / 60;
    var seconds = totalSeconds % (minutes * 60);
    var days = hours / 24;
    var hoursToDisplay = hours - (24 * days);
    var daysTotal = totalSeconds / (24 * 60 * 60f);
    Console.WriteLine($"""
                       seconds: {seconds}
                       minutes: {minutes},
                       hours: {hoursToDisplay},
                       days: {days},
                       """);
    Console.WriteLine($"{days}.{hoursToDisplay}:{minutes}:{seconds}");
    Console.WriteLine($"In total it's {daysTotal} days");
};