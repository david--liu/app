 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(RequestProcessorRegistry))]  
    public class RequestProcessorRegistrySpecs
    {
        public abstract class concern : Observes<IFindRequestProcessors,
                                            RequestProcessorRegistry>
        {
        
        }

   
        public class when_finding_a_processor_for_a_request : concern
        {

            public class and_it_has_the_processor
            {
                Establish c = () =>
                {
                    all_the_possible_processors = Enumerable.Range(1,100).Select(x => fake.an<IProcessOneRequest>()).ToList();
                    request = fake.an<IContainRequestDetails>();
                    the_one_that_can_process = fake.an<IProcessOneRequest>();

                    all_the_possible_processors.Add(the_one_that_can_process);

                    the_one_that_can_process.setup(x => x.can_process(request)).Return(true);

                    depends.on<IEnumerable<IProcessOneRequest>>(all_the_possible_processors);
                };

                Because b = () =>
                    result = sut.get_the_command_that_can_handle(request);

                It should_return_the_processor_that_can_handle_the_request = () =>
                    result.ShouldEqual(the_one_that_can_process);

                static IProcessOneRequest result;
                static IProcessOneRequest the_one_that_can_process;
                static IContainRequestDetails request;
                static IList<IProcessOneRequest> all_the_possible_processors;
            }
                
        }
    }
}
