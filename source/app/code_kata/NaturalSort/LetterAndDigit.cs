using System;

namespace app.code_kata.NaturalSort
{
    public abstract class LetterAndDigit : IComparable
    {
        public abstract int CompareTo(object obj);
    }
}