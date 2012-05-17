using Machine.Specifications;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;

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
            It first_observation = () => 
        }
    }
}