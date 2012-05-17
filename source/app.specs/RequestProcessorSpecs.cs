using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(RequestProcessor))]
    public class RequestProcessorSpecs
    {
        public abstract class concern : Observes<IProcessOneRequest,
                                            RequestProcessor>
        {
        }

        public class when_determining_if_it_can_process_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestDetails>();
                depends.on<RequestMatch_Behaviour>(x =>
                {
                    x.ShouldEqual(request);
                    return true;
                });
            };

            Because b = () =>
                result = sut.can_process(request);

            It should_make_its_determination_by_leveraging_its_request_specification = () =>
                result.ShouldBeTrue();

            static bool result;
            static IContainRequestDetails request;
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                app_behaviour = depends.on<ISupportAFeature>();
                request = fake.an<IContainRequestDetails>();
            };

            Because b = () =>
                sut.process(request);

            It should_delegate_to_the_application_specific_functionality = () =>
                app_behaviour.process(request);

            static IContainRequestDetails request;
            static ISupportAFeature app_behaviour;
        }
    }
}