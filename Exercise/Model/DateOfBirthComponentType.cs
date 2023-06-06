using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Model.Services;

namespace Exercise.Model
{
    public class DateOfBirthComponentType : StringEnum<DateOfBirthComponentType>
    {
        public DateOfBirthComponentType(string value) : base(value)
        {

        }

        public static implicit operator DateOfBirthComponentType(string value)
        {
            return new DateOfBirthComponentType(value);
        }

        public static DateOfBirthComponentType Year = new DateOfBirthComponentType(nameof(Year));
        public static DateOfBirthComponentType Month = new DateOfBirthComponentType(nameof(Month));
        public static DateOfBirthComponentType Day = new DateOfBirthComponentType(nameof(Day));

        public static List<DateOfBirthComponentType> AllComponents = new List<DateOfBirthComponentType> { Year, Month, Day };
    }
}
