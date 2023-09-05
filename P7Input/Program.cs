// See https://aka.ms/new-console-template for more information

Console.WriteLine("What's your Name?");
string name = Console.ReadLine() ?? "Anonymous";
Console.WriteLine($"Hi {name}!!!");