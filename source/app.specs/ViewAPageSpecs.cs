 using System;
 using Machine.Specifications;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ViewAPage<AReportModel>))]  
    public class ViewAPageSpecs
    {
        public abstract class concern : Observes<ISupportAFeature,
                                            ViewAPage<AReportModel>>
        {
        
        }

   
        public class when_run : concern
        {
            Establish c = () =>
            {
                the_report_model = new AReportModel();
                depends.on<Func<IContainRequestDetails, AReportModel>>(x => the_report_model);
                display_engin = fake.an<IDisplayInformation>();
                depends.on(display_engin);
            };

            Because b = () =>
            {
                sut.process(model);
            };


            It should_display_specified_model = () =>
            {
                display_engin.received(x => x.display(the_report_model));
            };

            static IContainRequestDetails model;
            static AReportModel the_report_model;
            static IDisplayInformation display_engin;
        }
    }

    public class AReportModel
    {
    }
}
