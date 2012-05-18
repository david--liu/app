using System;
using System.Linq.Expressions;
using Machine.Specifications;
using developwithpassion.specifications.extensions;

namespace app.specs.spikes
{
    public class ExpressionTreeSpikes
    {

        public class Person
        {
            public Person()
            {
            }
            public Person(string name)
            {
            }
        }
        public class when_messing_around_with_expressions
        {
            It should_be_able_to_do_stuff = () =>
            {
                Expression<Func<Person>> ctor = () => new Person(string.Empty);
                ctor.Body.downcast_to<NewExpression>().Constructor.Invoke(new object[]{"blaha"});

                Expression<Func<ASPNetHandlerSpecs.Person, string>> name_accessor = x => x.the_name;

                Func<int, bool> is_even = x => x%2 == 0;

                ConstantExpression zero = Expression.Constant(0);
                ConstantExpression two = Expression.Constant(2);
                ParameterExpression parameter_expression = Expression.Parameter(typeof(int), "x");
                BinaryExpression modulus_expression = Expression.Modulo(parameter_expression, two);
                BinaryExpression equal = Expression.Equal(modulus_expression, zero);

                var even_built_on_the_fly = Expression.Lambda<Func<int, bool>>(equal, parameter_expression);

                Func<int, bool> dynamic_mod = even_built_on_the_fly.Compile();
                dynamic_mod(2).ShouldBeTrue();
            };
                 
        } 
    }
}