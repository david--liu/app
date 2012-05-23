 using System.Collections.Generic;
 using Machine.Specifications;
 using code_kata.integer_stack;
 using developwithpassion.specifications.rhinomocks;

namespace code_kata.Specs
{  
    [Subject(typeof(IntegerStack))]  
    public class IntegerStackSpecs
    {
        public abstract class concern : Observes<IStack,
                                            IntegerStack>
        {
        
        }

   
        public class when_pop_from_the_stack : concern
        {
            Establish c = () =>
            {
                expected_number = 5;
                values = new List<int> {6, 7, 5};
                depends.on(values);

            };
            Because b = () =>
                result = sut.pop();


            It should_pop_the_last_value = () =>
                result.ShouldEqual(expected_number);

            It should_shrink_the_stack_by_one = () =>
                values.Count.ShouldEqual(2);
            static int result;
            static int expected_number;
            static List<int> values;
        }

        public class when_push_into_the_stack : concern
        {
            Establish c = () =>
            {
                values = new List<int> { 6, 7 };
                depends.on(values);
            };
            Because b = () =>
                sut.push(5);


            It should_push_value_to_the_top = () =>
                values[2].ShouldEqual(5);

            It should_increase_stack_count_by_one = () =>
                values.Count.ShouldEqual(3);
                
            static int result;
            static int expected_number;
            static List<int> values;
        }

        public class when_counting_the_stack : concern
        {
            Establish c = () =>
            {

                var values = new List<int> { 6, 7, 8 };
                depends.on(values);
                
            };

            Because b = () =>
                result = sut.count();

            It should_return_the_correct_count = () =>
                result.ShouldEqual(3);

            static int result;
        }

        public class integrated_test : concern
        {
            Establish c = () =>
            {
                expected_value = 5;
                stack = new IntegerStack();
                stack.push(1);
                stack.push(2);
                stack.push(expected_value);
            };
            Because b = () =>
                result = stack.pop();

            It should_pop_just_pushed_value = () =>
                result.ShouldEqual(expected_value);

            static int result;
            static int expected_value;
            static IntegerStack stack;
        }
    }
}
