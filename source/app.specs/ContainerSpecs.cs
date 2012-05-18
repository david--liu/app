using Machine.Specifications;
using app.infrastructure.containers;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof(Container))]
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {

        }

        public class when_providing_access_to_the_container_facade : concern
        {
            Establish c = () =>
            {
                the_container_facade = fake.an<IFetchDependencies>();
                ContainerFacadeResolution_Behaviour facade_resolution = () => the_container_facade;

                spec.change(() => Container.facade_resolution).to(facade_resolution);
            };
            Because b = () =>
                result = Container.fetch;

            It should_return_the_facade_configured_at_startup = () =>
                result.ShouldEqual(the_container_facade);

            static IFetchDependencies result;
            static IFetchDependencies the_container_facade;
        }
    }
}
