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
                product_repository = depends.on<IFindInformationAboutTheStore>();
                display_engine = depends.on<IDisplayInformation>();
                request_input_model = new ViewTheProductsInADepartmentRequest();
                request = fake.an<IContainRequestDetails>();
                products = new List<ProductDisplayItem>() {new ProductDisplayItem()};
                
                request.setup(x => x.map<ViewTheProductsInADepartmentRequest>()).Return(request_input_model);
                product_repository.setup(x => x.get_the_products_in(request_input_model)).Return(products);
            };


            Because b = () =>
                sut.process(request);


            It should_display_the_products = () =>
                display_engine.received(x => x.display(products));

            static IDisplayInformation display_engine;
            static ViewTheProductsInADepartmentRequest request_input_model;
            static IContainRequestDetails request;
            static IEnumerable<ProductDisplayItem> products;
            static IFindInformationAboutTheStore product_repository;
        }
    }
}
