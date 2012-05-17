using System.Web;
using Machine.Specifications;
using app.specs.utility;
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
                view_registry = depends.on<IFindViews>();
                view = fake.an<IHttpHandler>();
                current_context = ObjectFactory.web.create_http_context();
                depends.on<GetTheCurrentContext_Behaviour>(() => current_context);
                model = new object();

                view_registry.setup(x => x.find_view_that_can_display(model)).Return(view);
            };

            Because b = () =>
                sut.display(model);

            It should_get_the_view_that_can_display_the_report_model = () =>
            {

            };

            It should_tell_the_view_to_process_using_the_currently_executing_context = () =>
                view.received(x => x.ProcessRequest(current_context));


                

            static IFindViews view_registry;
            static object model;
            static IHttpHandler view;
            static HttpContext current_context;
        }
    }
}