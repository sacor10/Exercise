using AgeCalculator;
using Exercise.Controller;
using Exercise.Model;
using Exercise.Service.Interface;

namespace Exercise.Service;

public class DateOfBirthService : IDateOfBirthService
{
    public User GetUserDateOfBirth(User user)
    {
        Console.WriteLine("Let's start with your year of birth.");
        var yearOfBirth = Console.ReadLine();
        ValidateDobComponent(yearOfBirth, DateOfBirthComponentType.Year);

        Console.WriteLine("Thanks! Let's get your month of birth. Please enter that now.");
        var monthOfBirth = Console.ReadLine();
        ValidateDobComponent(monthOfBirth, DateOfBirthComponentType.Month);

        Console.WriteLine("You're doing great! Now for your day of birth. Ready for that whenever you are.");
        var dayOfBirth = Console.ReadLine();
        ValidateDobComponent(dayOfBirth, DateOfBirthComponentType.Day);

        var success = DateTime.TryParse($"{yearOfBirth}/{monthOfBirth}/{dayOfBirth}", out var dateOfBirth);

        if (success)
        {
            user.Birthday = dateOfBirth;
            Console.WriteLine($"Your date of birth is {dateOfBirth.ToShortDateString()}.");

            if (dateOfBirth.Day == DateTime.Today.Day && dateOfBirth.Month == DateTime.Today.Month)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Happy birthday my dude!");
            }

            var age = CalculateAge(user);
            user.Age = age;

            return user;
        }

        user.Birthday = default;
        return user;
    }

    private int CalculateAge(User user)
    {
        var age = new Age(user.Birthday, DateTime.Today);

        Console.WriteLine($"You are {age.Years} years old!");

        if (age.Years > 120)
        {
            Console.WriteLine("Wait a second, how are you so old? What's your secret?? Your age is not possible.");
            Program.Main(null);
        }

        if (age.Years <= 0)
        {
            Console.WriteLine("Hold your horses junior, I don't think you have been born yet!");
            Program.Main(null);
        }

        return age.Years;
    }

    private void ValidateDobComponent(string? dobComponent, DateOfBirthComponentType dobComponentType)
    {
        var success = int.TryParse(dobComponent, out var validDobComponent);

        if (!success)
        {
            Console.WriteLine($"Invalid date of birth entry, please enter a valid date of birth {dobComponentType}.");
            Program.Main(null);
        }
    }
}