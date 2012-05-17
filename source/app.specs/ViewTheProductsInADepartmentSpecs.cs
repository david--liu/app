 using System.Collections.Generic;
 using Machine.Specifications;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ViewTheProductsInADepartment))]  
    public class ViewTheProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<ISupportAFeature,ViewTheProductsInADepartment>
        {
        
        }

   
        public class when_run : concern
        {
            Establish c = () =>
            {
                product_repository = depends.on<IFindProducts>();
                display_engine = depends.on<IDisplayInformation>();
                the_selected_department = new DepartmentSelection();
                request = fake.an<IContainRequestDetails>();
                
                request.setup(x => x.map<DepartmentSelection>()).Return(the_selected_department);
                product_repository.setup(x => x.get_the_products_in(the_selected_department)).Return(products);
            };


            Because b = () =>
                sut.process(request);


            It should_display_the_products = () =>
                display_engine.received(x => x.display(products));

            static IDisplayInformation display_engine;
            static DepartmentSelection the_selected_department;
            static IContainRequestDetails request;
            static IEnumerable<ProductDisplayItem> products;
            static IFindProducts product_repository;
        }
    }
}
