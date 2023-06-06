using Exercise.Model;

namespace Exercise.Service.Interface;

public interface IDateOfBirthService
{
    void Validate(string? dobComponent, DateOfBirthComponentType dobComponentType);
}