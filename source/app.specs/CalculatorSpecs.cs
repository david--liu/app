using System;
using System.Data;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

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
                //ARRANGE
                Establish c = () =>
                {
                    connection = depends.on<IDbConnection>(); 
                };

                //ACT
                Because b = () =>
                    result = sut.add(2, 3);

                //ASSERT

                It should_open_a_connection_to_the_database = () =>
                    connection.received(x => x.Open());
                    
                It should_return_the_sum = () =>
                    result.ShouldEqual(5);

                static int result;
                static IDbConnection connection;
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