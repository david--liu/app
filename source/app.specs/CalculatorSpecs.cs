using System;
using Machine.Specifications;
using Rhino.Mocks.Expectations;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator>
        {
            
        }

        public class when_adding : concern
        {
            public class two_positive_numbers
            {
                //ACT
                Because b = () =>
                    result = sut.add(2, 3);


                //ASSERT
                It should_return_the_sum = () =>
                    result.ShouldEqual(5);

                static int result;

            }

            public class a_negative_to_a_positive
            {

                //ACT
                Because b = () =>
                    spec.catch_exception(() => sut.add(2, -3));


                //ASSERT
                It should_throw_an_argument_exception = () =>
                    spec.exception_thrown.ShouldBeAn<ArgumentException>();


            }
        }
    }
}