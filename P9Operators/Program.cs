// See https://aka.ms/new-console-template for more information

Console.WriteLine("Write an amount of seconds:");
var userInput = Console.ReadLine();
if (int.TryParse(userInput, out var totalSeconds))
{
    var seconds = totalSeconds % 60;
    var minutes = totalSeconds % 60;
    var hours = totalSeconds % 24;
    var days = totalSeconds % 60;
    
};