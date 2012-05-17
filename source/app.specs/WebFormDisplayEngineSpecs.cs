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
                data_store = depends.on<IDataStore>();
                
            };

            Because b = () =>
                sut.display(model);


            It should_store_info_in_a_data_store = () =>
            {
                data_store.received(x => x.store(model));
            };
            static object model; 
            static IDataStore data_store;
        }

       
    }
}