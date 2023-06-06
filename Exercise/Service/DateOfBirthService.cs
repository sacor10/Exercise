using Exercise.Model;
using Exercise.Service.Interface;

namespace Exercise.Service;

public class DateOfBirthService : IDateOfBirthService
{
    public void Validate(string? dobComponent, DateOfBirthComponentType dobComponentType)
    {
        var success = int.TryParse(dobComponent, out var validDobComponent);

        if (!success)
        {
            Console.WriteLine("Invalid date of birth entry, please enter a valid ");
        }
    }
}