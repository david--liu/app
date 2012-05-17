using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ViewDepartmentsWithInDepartment))]
    public class ViewDepartmentsWithInADepartmentSpecs
    {
        public abstract class concern : Observes<ISupportAFeature,
                                            ViewDepartmentsWithInDepartment>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                repository = depends.on<IFindDepartments>();
                display_engine = depends.on<IDisplayInformation>();
                request = fake.an<IContainRequestDetails>();

                sub_departments = new List<DepartmentDisplayItem>() { new DepartmentDisplayItem () };

                repository.setup(x => x.get_the_sub_departments_in_the_department(request)).Return(sub_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_display_the_sub_departments_in_a_given_departemnt = () =>
                display_engine.received(x => x.display(sub_departments));

            static IContainRequestDetails request;
            static IFindDepartments repository;
            static IDisplayInformation display_engine;
            static IEnumerable<DepartmentDisplayItem> sub_departments;
        }
    }
}