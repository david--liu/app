 using System;
 using System.Linq.Expressions;
 using System.Web;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web.application.catalogbrowsing;
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


        public class Person
        {
            public string the_name { get; set; }
        }
        public class when_processing_an_http_context : concern
        {
            Establish c = () =>
            {
                var person = new Person {the_name = "JP"};

//                Url.to_run<ViewTheProductsInADepartmentRequest>().encode_using(department,product)
//                    .include(department, config => config.include_all_except(x => x.name))
//                    .include(product, config => config.include_all_except(x => x.image))
//                    .include_existing_payload

                front_controller = depends.on<IProcessWebRequests>();
                request_factory = depends.on<ICreateRequests>();

                a_new_request = fake.an<IContainRequestDetails>();
                new_http_context = ObjectFactory.web.create_http_context();

                request_factory.setup(x => x.create_request_from(new_http_context)).Return(a_new_request);
            };
            Because b = () =>
                sut.ProcessRequest(new_http_context);


            It should_delegate_processing_of_a_new_controller_request_to_the_front_controller = () =>
                front_controller.received(x => x.process(a_new_request));

            static IProcessWebRequests front_controller;
            static IContainRequestDetails a_new_request;
            static HttpContext new_http_context;
            static ICreateRequests request_factory;
        }
    }
}
