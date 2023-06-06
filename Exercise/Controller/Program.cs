using Exercise.Service;

namespace Exercise.Controller;

public class Program
{

    public Program()
    {
        
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the program. Please enter your date of birth.");
        Console.WriteLine("Let's start with your year of birth.");
        var yearOfBirth = Console.ReadLine();

        var dobService = new DateOfBirthService();

    }
}