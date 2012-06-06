using System;

namespace app.code_kata.NaturalSort
{
    public class Digit : LetterAndDigit
    {
        int value;

        public Digit(int value)
        {
            this.value = value;
        }


        public override int CompareTo(object obj)
        {
            if(obj is int)
            {
                return value.CompareTo((int) obj);
            }
            else if(obj is Digit)
            {
                return value.CompareTo((obj as Digit).value);
            }
            else if(obj is NullLetterOrDigit)
            {
                return 1;
            }

            return -1;
        }
    }


}