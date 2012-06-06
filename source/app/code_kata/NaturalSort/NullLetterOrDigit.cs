using System;

namespace app.code_kata.NaturalSort
{
    public class NullLetterOrDigit : LetterAndDigit
    {

        public override int CompareTo(object obj)
        {
            return -1;
        }
    }
}