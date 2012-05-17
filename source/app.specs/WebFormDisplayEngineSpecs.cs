using Machine.Specifications;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof(WebFormDisplayEngine))]
    public class WebFormDisplayEngineSpecs
    {
        public abstract class concern : Observes<IDisplayInformation,
                                            WebFormDisplayEngine>
        {
        }

        public class when_displaying_an_item : concern
        {
            Establish c = () =>
            {
                contain_data_for_client = depends.on<IContainDataForClient>();
                
            };

            Because b = () =>
                sut.display(model);


            It should_store_info_in_a_data_store_that_client_has_access_to = () =>
            {
                contain_data_for_client.received(x => x.store(model));
            };
            static object model; 
            static IContainDataForClient contain_data_for_client;
        }

       
    }
}