using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ViewTheMainDepartmentsInTheStore))]  
    public class ViewTheMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ISupportAFeature,
                                            ViewTheMainDepartmentsInTheStore>
        {
        
        }

   
        public class when_run : concern
        {
            Establish c = () =>
            {
                repository = depends.on<IFindInformationAboutTheStore>();
                display_engine = depends.on<IDisplayInformation>();
                request = fake.an<IContainRequestDetails>();
                main_departments = new List<DepartmentDisplayItem>() {new DepartmentDisplayItem()};

                repository.setup(x => x.get_the_main_departments_in_the_store()).Return(main_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_get_the_main_departments = () =>
            {

            };

            It should_display_the_main_departments = () =>
                display_engine.received(x => x.display(main_departments));
                

            static IContainRequestDetails request;
            static IFindInformationAboutTheStore repository;
            static IEnumerable<DepartmentDisplayItem> main_departments;
            static IDisplayInformation display_engine;
        }
    }
}
