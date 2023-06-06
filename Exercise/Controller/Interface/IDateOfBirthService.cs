using Exercise.Model;

namespace Exercise.Controller.Interface;

public interface IDateOfBirthService
{
    User GetUserDateOfBirth(User user);
}