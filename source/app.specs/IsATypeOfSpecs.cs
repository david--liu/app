using System.Data;
using Machine.Specifications;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(IsATypeOf))]
    public class IsATypeOfSpecs
    {
        public abstract class concern : Observes<IsATypeOf>
        {
        }

        public class when_matching_an_type : concern
        {
            Establish c = () =>
            {
                depends.on(typeof(IDbConnection));
            };
            Because b = () =>
                result = sut.matches(typeof(IDbConnection));

            It should_match_if_the_type_is_the_expected_type = () =>
                result.ShouldBeTrue();

            static bool result;
        }
    }
}