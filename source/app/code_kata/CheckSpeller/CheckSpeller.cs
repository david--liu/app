using System;
using System.Collections.Generic;

namespace app.code_kata.CheckSpeller
{
    public class CheckSpeller : ISpellCheck
    {
        static Dictionary<int, string> map = new Dictionary<int, string>()
        {
            {0, string.Empty},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Fourty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninety"}
        };
        public string Spell(decimal check)
        {
            var dollars = (int)Math.Floor(check);
            var cents = (check - dollars) * 100;
            
            if(cents != 0)
            {
                if(dollars == 0)
                {
                    return FormatCents(cents);
                }
                else
                {
                    return string.Format("{0} and {1}", GetDisplay(dollars), FormatCents(cents));
                }
            }
            else
            {
                return string.Format("{0} Dollars", GetDisplay(dollars).Trim());
            }
        }

        static string GetDisplay(int dollars)
        {
            if(map.ContainsKey(dollars))
                return map[dollars];

            if (dollars == 0)
                return string.Empty;

            if(dollars>= 1000*1000)
            {
                throw new NotSupportedException("To be completed");
            }

            if(dollars >= 1000)
            {
                return GetDisplayForThousands(dollars);
            }
            if (dollars >= 100)
            {
                return GetDisplayForHundreds(dollars);
            }
            return GetDisplayForDollarLessThanOneHundred(dollars);
        }

        static string GetDisplayForDollarLessThanOneHundred(int dollars)
        {
            var tens = (int) Math.Floor(dollars/10m)*10;
            return string.Format("{0}-{1}", map[tens], map[dollars - tens].ToLower());
        }
        static string GetDisplayForHundreds(int dollars)
        {
            var hundreds = (int) Math.Floor(dollars/100m);
            var tens = dollars - hundreds*100;

            return string.Format("{0} hundred {1}", map[hundreds], tens == 0 ? string.Empty : GetDisplayForDollarLessThanOneHundred(tens).ToLower());
        }
         
        static string GetDisplayForThousands(int dollars)
        {
            var thousands = (int) Math.Floor(dollars/1000m);
            return string.Format("{0} thousand {1}", GetDisplay(thousands), GetDisplay(dollars - thousands * 1000).ToLower());
        }


        static string FormatCents(decimal cents)
        {
            return string.Format("{0:F0}/100 Dollars", cents);
        }
    }
}