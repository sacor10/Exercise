using System.Reflection;

namespace Exercise.Model.Services
{


    public class StringEnum<T> : StringEnum where T : StringEnum<T>
    {
        public StringEnum(string value) : base(value) { }

        public static IEnumerable<T> GetValues()
        {
            Type type = typeof(T);

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);

            var validFields = fields.Where(x => x.FieldType == typeof(T)).ToList();

            var results = validFields.Select(x => (T)x.GetValue(null));

            return results;
        }
    }

    public class StringEnum : IComparable<StringEnum>
    {
        protected StringEnum(string value)
        {
            Value = value;
        }

        public string Value { get; }


        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            string value;

            if (obj is string)
            {
                value = (string)obj;
            }
            else if (obj is StringEnum)
            {
                value = ((StringEnum)obj).Value;
            }
            else
            {
                return false;
            }

            return string.Equals(Value, value);


        }

        public bool Equals(StringEnum x)
        {
            // If parameter is null return false:
            if ((object)x == null)
            {
                return false;
            }

            // Return true if the fields match:
            return string.Equals(Value, x.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }


        public static bool operator ==(StringEnum x, StringEnum y)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(x, y))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return string.Equals(x.Value, y.Value);

            // Return true if the fields match:

        }

        public static bool operator !=(StringEnum x, StringEnum y)
        {
            return !(x == y);
        }

        public int CompareTo(StringEnum other)
        {
            return String.Compare(this.Value, other.Value, StringComparison.CurrentCulture);
        }

        public static implicit operator string(StringEnum e)
        {
            return e?.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}