// See https://aka.ms/new-console-template for more information
/*
Console.WriteLine("""
                  Welcome to the km/h to m/s converter!
                  Enter a value in km/h
                  """);
var userInput = Console.ReadLine();
var kmHValue = float.Parse(userInput!);
var milesPerSecValue = (kmHValue / 3600) * 1000;
Console.WriteLine($"You are going at {milesPerSecValue} m/s");
// km/h * 1000
// result / 3600
*/

Console.WriteLine("""
                  Welcome to the minutes to seconds converter!
                  Enter a value:
                  """);
var userInput = Console.ReadLine();
var minutes = int.Parse(userInput!);
var seconds = minutes * 60;
Console.WriteLine($"{minutes} minutes is {seconds} seconds in total");
