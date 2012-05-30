using System;
using System.Text;

namespace app.code_kata.NaturalSort
{
    public class LetterAndDigitParser : ILetterAndDigitParser
    {
        public LetterDigitContainer Parse(string entry)
        {
            var result = new LetterDigitContainer();
            var stringBuilder = new StringBuilder();
            var digitBuilder = new StringBuilder();
            foreach (var chr in entry)
            {

                if(char.IsNumber(chr))
                {
                    digitBuilder.Append((int)Char.GetNumericValue(chr));
                    CreateLetterGroup(result, stringBuilder);
                }
                else
                {
                    stringBuilder.Append(chr);
                    CreateDigitGroup(result, digitBuilder);
                }

            }

            CreateDigitGroup(result, digitBuilder);
            CreateLetterGroup(result, stringBuilder);

            return result;
        }

        static void CreateLetterGroup(LetterDigitContainer result, StringBuilder stringBuilder)
        {
            if (stringBuilder.Length > 0)
            {
                result.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
        }

        static void CreateDigitGroup(LetterDigitContainer result, StringBuilder digitBuilder)
        {
            if (digitBuilder.Length > 0)
            {
                result.Add(Convert.ToInt32(digitBuilder.ToString()));
                digitBuilder.Clear();
            }
        }
    }
}