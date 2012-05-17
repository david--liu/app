 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using app.web.core;

namespace app.specs
{  
    [Subject(typeof(RequestProcessor))]  
    public class RequestProcessorSpecs
    {
        public abstract class concern : Observes<IProcessOneRequest,
                                            RequestProcessor>
        {
        
        }


        public class when_asked_if_you_can_process_a_request : concern
        {
            Establish c = () =>
            {
                fake.an<IContainRequestDetails>();
            };

            Because b = () =>
            {
                response = sut.can_process(request);
            };


            It should_return_true_when_the_request_can_be_processed = () =>
            {
                response.ShouldBeTrue();
            };

            static bool response;
            static IContainRequestDetails request;
        }
    }
}
