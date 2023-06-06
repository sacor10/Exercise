using Exercise.Model;

namespace Exercise.Service.Interface;

public interface IDateOfBirthService
{
    User GetUserDateOfBirth(User user);
}