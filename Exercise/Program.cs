﻿using Exercise.Controller;
using Exercise.Controller.Interface;
using Exercise.Model;

namespace Exercise;

public class Program
{
    private static readonly IDateOfBirthService DobService = new DateOfBirthService();

    public static void Main(string[] args)
    {
        User newUser = new User();
        Console.WriteLine("Welcome to the program. Please enter your date of birth. This will be YYYY/MM/DD format.");

        var dobUser = DobService.GetUserDateOfBirth(newUser);
    }
}