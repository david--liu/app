 using System.Collections.Generic;
 using Machine.Specifications;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ISupportAFeature))]  
    public class ViewTheDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<ISupportAFeature,ViewTheDepartmentsInADepartment>
        {
        
        }

   
        public class when_run  : concern
        {
            Establish c = () =>
            {
                department_repository = depends.on<IFindDepartments>();
                display_engine = depends.on<IDisplayInformation>();
                the_selected_department = new DepartmentSelection();
                request = fake.an<IContainRequestDetails>();
                sub_departments = new List<DepartmentDisplayItem>(){new DepartmentDisplayItem()};

                request.setup(x => x.map<DepartmentSelection>()).Return(the_selected_department);
                department_repository.setup(x => x.get_the_departments_in(the_selected_department)).Return(sub_departments);
            };


            Because b = () =>
                sut.process(request);

            It should_display_the_sub_departments = () =>
                display_engine.received(x => x.display(sub_departments));

            static IDisplayInformation display_engine;
            static DepartmentSelection the_selected_department;
            static IContainRequestDetails request;
            static IEnumerable<DepartmentDisplayItem> sub_departments;
            static IFindDepartments department_repository;
        }
    }
}
