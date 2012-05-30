using System.Collections.Generic;
 using Machine.Specifications;
 using app.code_kata.NaturalSort;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace code_kata.Specs.NaturalSort
{  
    [Subject(typeof(LetterAndDigitParser))]  
    public class LetterAndDigitParserSpecs
    {
        public abstract class concern : Observes<ILetterAndDigitParser,
                                            LetterAndDigitParser>
        {
        
        }

   
        public class when_parse_a_string : concern
        {
            Because b = () =>
               result = sut.Parse("abc123");


            It should_break_into_letters_and_digits = () =>
            {
                result.GetValue(0).ShouldBeAn<Letter>();
                result.GetValue(1).ShouldBeAn<Digit>();
                result.GetValue(0).CompareTo("abc").ShouldEqual(0);
                result.GetValue(1).CompareTo(123).ShouldEqual(0);
            };
            static LetterDigitContainer result;
                
        }
        public class when_parse_a_complex_string : concern
        {
            Because b = () =>
               result = sut.Parse("abc123 X1");


            It should_break_into_letters_and_digits = () =>
            {
                result.GetValue(0).CompareTo("abc").ShouldEqual(0);
                result.GetValue(1).CompareTo(new Digit(123)).ShouldEqual(0);
                result.GetValue(2).CompareTo(" X").ShouldEqual(0);
                result.GetValue(3).CompareTo(1).ShouldEqual(0);
            };
            static LetterDigitContainer result;
                
        }
    }
}
