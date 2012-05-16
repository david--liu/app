 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(FrontController))]  
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<IProcessWebRequests,
                                            FrontController>
        {
        
        }

   
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                command_registry = depends.on<IFindRequestProcessors>();

                the_request = fake.an<IContainRequestDetails>();
                the_command_that_can_handle_the_request = fake.an<IProcessOneRequest>();

                command_registry.setup(x => x.get_the_command_that_can_handle(the_request)).Return(the_command_that_can_handle_the_request);
            };

            Because b = () =>
                sut.process(the_request);


            It should_delegate_the_processing_to_the_command_that_can_handle_the_request = () =>
                the_command_that_can_handle_the_request.received(x => x.process(the_request));

            static IProcessOneRequest the_command_that_can_handle_the_request;
            static IContainRequestDetails the_request;
            static IFindRequestProcessors command_registry;
        }
    }
}
