 using Machine.Specifications;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ISupportAFeature))]  
    public class ViewAnyDepartmentInTheStoreSpecs
    {
        public abstract class concern : Observes<ISupportAFeature>
        {
        
        }

   
        public class when_viewing_a_department  : concern
        {
            Establish c = () =>
            {
                display_engine = depends.on<IDisplayInformation>();
                a_department = new DepartmentDisplayItem();
                request = fake.an<IContainRequestDetails>();
            };

            Because b = () =>
                sut.process(request);

            It should_display_a_department = () =>
                display_engine.received(x => x.display_a_department(a_department));

            static IDisplayInformation display_engine;
            static DepartmentDisplayItem a_department;
            static IContainRequestDetails request;
        }
    }
}
