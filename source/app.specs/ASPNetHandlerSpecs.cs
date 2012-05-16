 using System.Web;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web.core;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ASPNetHandler))]  
    public class ASPNetHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            ASPNetHandler>
        {
        
        }

   
        public class when_processing_an_http_context : concern
        {
            Establish c = () =>
            {
                front_controller = depends.on<IProcessWebRequests>();
                request_factory = depends.on<ICreateControllerRequests>();
                a_new_request = new object();
                new_http_context = ObjectFactory.web.create_http_context();

                request_factory.setup(x => x.create_from(new_http_context)).Return(a_new_request);
            };
            Because b = () =>
                sut.ProcessRequest(new_http_context);


            It should_delegate_processing_of_a_new_controller_request_to_the_front_controller = () =>
                front_controller.received(x => x.process(a_new_request));

            static IProcessWebRequests front_controller;
            static object a_new_request;
            static HttpContext new_http_context;
            static ICreateControllerRequests request_factory;
        }
    }
}
