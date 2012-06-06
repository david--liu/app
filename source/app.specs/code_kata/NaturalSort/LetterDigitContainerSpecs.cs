using Machine.Specifications;
using app.code_kata.NaturalSort;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.Specs.NaturalSort
{
    [Subject(typeof(LetterDigitContainer))]
    public class LetterDigitContainerSpecs
    {
        public abstract class concern : Observes<ILetterDigitContainer, LetterDigitContainer>
        {
        }

        public class when_get_letters_from_the_container : concern
        {
            Because b = () =>
                sut.Add("ABC");

            It should_get_letters_back = () =>
            {
                sut.GetValue(0).CompareTo("ABC").ShouldEqual(0);
            };

            It should_get_empty_string_if_not_available = () =>
                sut.GetValue(1).CompareTo("ABC").ShouldEqual(-1);
        }

        public class when_add_item_to_the_container : concern
        {
            Because b = () =>
                sut.Add("blah");

            It should_get_correct_count = () =>
                sut.Count.ShouldEqual(1);
        }

        public class when_compare_two_letter_containers : concern
        {
            Because b = () =>
            {
                sut.Add("aaaa");
                var other = new LetterDigitContainer();
                other.Add("bbbb");
                result = sut.CompareTo(other);
            };

            It should_compare = () =>
                result.ShouldEqual(-1);

            static int result;
        }

        public class when_compare_two_digit_containers : concern
        {
            Because b = () =>
            {
                sut.Add(123);
                var other = new LetterDigitContainer();
                other.Add(1000);
                result = sut.CompareTo(other);
            };

            It should_compare = () =>
                result.ShouldEqual(-1);

            static int result;
        }

        public class when_compare_two_complex_containers : concern
        {
            Because b = () =>
            {
                sut.Add("abc");
                sut.Add(123);
                var other = new LetterDigitContainer();
                other.Add("abc");
                other.Add(1000);
                result = sut.CompareTo(other);
            };

            It should_compare = () =>
                result.ShouldEqual(-1);

            static int result;
        }

        public class when_compare_two_more_complex_containers : concern
        {
            Because b = () =>
            {
                sut.Add("abc");
                sut.Add(1000);
                sut.Add(1000);
                var other = new LetterDigitContainer();
                other.Add("abc");
                other.Add(1000);
                result = sut.CompareTo(other);
            };

            It should_compare = () =>
                result.ShouldEqual(1);

            static int result;
        }
    }
}