using System.Collections.Generic;

namespace app.code_kata.NaturalSort
{
    public class NaturalSort : INaturalSort
    {
        readonly ILetterAndDigitParser parser = new LetterAndDigitParser();

 
        public NaturalSort() 
        {
            
        }

        public void Sort(List<string> list)
        {
            list.Sort(OnComparison);
        }

        int OnComparison(string x, string y)
        {
            var containerX = parser.Parse(x);
            if (containerX == null)
                return -1;

            var containerY = parser.Parse(y);

            if (containerY == null)
                return 1;

            return containerX.CompareTo(containerY);
        }
    }
}