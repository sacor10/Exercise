using AgeCalculator;
using Exercise.Controller.Interface;
using Exercise.Model;
using Exercise.Model.Services;

namespace Exercise.Controller;

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
            Console.WriteLine($"Your date of birth is {dateOfBirth.ToShortDateString()}.");
            user.Birthday = dateOfBirth;

            var chineseSign = GetChineseAstrologicalSign(user);
            Console.WriteLine($"Your chinese astrological sign is the {chineseSign}.");

            var westernSign = GetWesternAstrologicalSign(user);
            Console.WriteLine($"Your western astrological sign is the {westernSign}.");

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

    private string GetWesternAstrologicalSign(User user)
    {
        var dayOfBirth = user.Birthday.Day;
        var monthOfBirth = user.Birthday.Month;

        switch (monthOfBirth)
        {
            case (1):
                if (dayOfBirth >= 1 && dayOfBirth <= 19)
                {
                    return WesternAstrologicalSign.Capricorn;
                }
                if (dayOfBirth >= 20 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Aquarius;
                }
                break;
            case (2):
                if (dayOfBirth >= 1 && dayOfBirth <= 18)
                {
                    return WesternAstrologicalSign.Aquarius;
                }
                if (dayOfBirth >= 19 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Pisces;
                }
                break;
            case (3):
                if (dayOfBirth >= 1 && dayOfBirth <= 20)
                {
                    return WesternAstrologicalSign.Pisces;
                }
                if (dayOfBirth >= 21 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Aries;
                }
                break;
            case (4):
                if (dayOfBirth >= 1 && dayOfBirth <= 19)
                {
                    return WesternAstrologicalSign.Aries;
                }
                if (dayOfBirth >= 20 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Taurus;
                }
                break;
            case (5):
                if (dayOfBirth >= 1 && dayOfBirth <= 20)
                {
                    return WesternAstrologicalSign.Taurus;
                }
                if (dayOfBirth >= 21 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Gemini;
                }
                break;
            case (6):
                if (dayOfBirth >= 1 && dayOfBirth <= 20)
                {
                    return WesternAstrologicalSign.Gemini;
                }
                if (dayOfBirth >= 21 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Cancer;
                }
                break;
            case (7):
                if (dayOfBirth >= 1 && dayOfBirth <= 22)
                {
                    return WesternAstrologicalSign.Cancer;
                }
                if (dayOfBirth >= 23 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Leo;
                }
                break;
            case (8):
                if (dayOfBirth >= 1 && dayOfBirth <= 22)
                {
                    return WesternAstrologicalSign.Leo;
                }
                if (dayOfBirth >= 23 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Virgo;
                }
                break;
            case (9):
                if (dayOfBirth >= 1 && dayOfBirth <= 22)
                {
                    return WesternAstrologicalSign.Virgo;
                }
                if (dayOfBirth >= 23 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Libra;
                }
                break;
            case (10):
                if (dayOfBirth >= 1 && dayOfBirth <= 22)
                {
                    return WesternAstrologicalSign.Libra;
                }
                if (dayOfBirth >= 23 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Scorpio;
                }
                break;
            case (11):
                if (dayOfBirth >= 1 && dayOfBirth <= 21)
                {
                    return WesternAstrologicalSign.Scorpio;
                }
                if (dayOfBirth >= 22 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Sagittarius;
                }
                break;
            case (12):
                if (dayOfBirth >= 1 && dayOfBirth <= 21)
                {
                    return WesternAstrologicalSign.Sagittarius;
                }
                if (dayOfBirth >= 22 && dayOfBirth <= 31)
                {
                    return WesternAstrologicalSign.Capricorn;
                }
                break;
        }

        return "";
    }

    private string GetChineseAstrologicalSign(User user)
    {
        var signIndex = user.Birthday.Year % ChineseAstrologicalSign.AllSigns.Count;
        return ChineseAstrologicalSign.AllSigns[signIndex];
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