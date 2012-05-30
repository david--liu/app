using System;
using System.Collections.Generic;

namespace app.code_kata.NaturalSort
{
    public interface ILetterDigitContainer : IComparable<LetterDigitContainer>
    {
        void Add(string letters);
        void Add(int integer);
        IComparable GetValue(int index);
        int Count { get; }
    }

    public class LetterDigitContainer : ILetterDigitContainer
    {
        List<LetterAndDigit> map = new List<LetterAndDigit>();

        public LetterDigitContainer()
        {
        }

        public void Add(string letters)
        {
            map.Add(new Letter(letters));
        }

        public void Add(int integer)
        {
            map.Add(new Digit(integer));
        }




        public IComparable GetValue(int index)
        {
            if (map.Count > index)
                return map[index];
            return new NullLetterOrDigit();
        }

        public int CompareTo(LetterDigitContainer other)
        {
            int maxGroups = this.Count > other.Count ? this.Count : other.Count;
            for (int i = 0; i < maxGroups; i++)
            {
                var result = this.GetValue(i).CompareTo(other.GetValue(i));
                if (result != 0)
                {
                    return result;
                }
            }

            return 0;
        }

        public int Count
        {
            get { return map.Count; }
        }
    }
}

 