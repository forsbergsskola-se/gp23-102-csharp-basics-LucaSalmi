﻿// See https://aka.ms/new-console-template for more information

var isChild = false;
var isTeenager = false;
var isAdult = false;
Console.WriteLine("Write your Age:");
var ageInput = Console.ReadLine();
if (int.TryParse(ageInput, out var age))
{
    SetBooleans(age);
}
else
{
    Console.WriteLine("Invalid Input");
}

return;


void SetBooleans(int num)
{
    switch (num)
    {
        case < 13:
            isChild = true;
            break;
        case > 19:
            isAdult = true;
            break;
        default:
            isTeenager = true;
            break;
    }

    Console.WriteLine($"You are a Child: {isChild}");
    Console.WriteLine($"You are a Teenager: {isTeenager}");
    Console.WriteLine($"You are an Adult: {isAdult}");
}