 using System;
 using Machine.Specifications;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ViewA<AReportModel>))]  
    public class ViewASpecs
    {
        public abstract class concern : Observes<ISupportAFeature,
                                            ViewA<AReportModel>>
        {
        
        }

   
        public class when_run : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestDetails>();
                the_report_model = new AReportModel();
                query = depends.on<IFetchAn<AReportModel>>();
                display_engine = fake.an<IDisplayInformation>();
                depends.on(display_engine);


                query.setup(x => x.run_using(request)).Return(the_report_model);
            };

            Because b = () =>
            {
                sut.process(request);
            };


            It should_display_the_model_found_using_the_query = () =>
                display_engine.received(x => x.display(the_report_model));

            static IContainRequestDetails request;
            static AReportModel the_report_model;
            static IDisplayInformation display_engine;
            static IFetchAn<AReportModel> query;
        }
    }

    public class AReportModel
    {
    }
}
