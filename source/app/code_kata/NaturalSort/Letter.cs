using System;

namespace app.code_kata.NaturalSort
{
    public class Letter : LetterAndDigit
    {
        string value;

        public Letter(string value)
        {
            this.value = value;
        }

  
        public override int CompareTo(object obj)
        {
            if(obj is String)
            {
                return System.String.CompareOrdinal(value, (string)obj);
            }
            else if(obj is Letter)
            {
                return System.String.CompareOrdinal(value, (obj as Letter).value);
            }
            else if(obj is NullLetterOrDigit)
            {
                return 1;
            }
            return string.CompareOrdinal(value, obj.ToString());
        }
    }
}