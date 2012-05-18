using Machine.Specifications;
using app.infrastructure.containers;
using app.startup;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof(Startup))]
    public class StartupSpecs
    {
        public abstract class concern : Observes
        {
        }

        public class when_completed : concern
        {
            Because b = () =>
                Startup.run();

            It should_be_able_to_access_key_services = () =>
            {
                Container.fetch.an<IProcessWebRequests>().ShouldBeAn<FrontController>();
            };
        }
    }
}