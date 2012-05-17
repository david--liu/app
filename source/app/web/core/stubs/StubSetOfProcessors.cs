using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;

namespace app.web.core.stubs
{
    public class StubSetOfProcessors : IEnumerable<IProcessOneRequest>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IProcessOneRequest> GetEnumerator()
        {
            yield return
                new RequestProcessor(x => true,
                                     new ViewA<IEnumerable<DepartmentDisplayItem>>(new GetTheMainDepartmentsInTheStore()))
                ; 
            yield return
                new RequestProcessor(x => true,
                                     new ViewA<IEnumerable<ProductDisplayItem>>(new GetTheProductsInADepartment()))
                ; 
        }
    }

    public class GetTheProductsInADepartment : IFetchAn<IEnumerable<ProductDisplayItem>>
    {
        public IEnumerable<ProductDisplayItem> run_using(IContainRequestDetails request)
        {
            return new StubStoreCatalog().get_the_products_in(request.map<ViewTheProductsInADepartmentRequest>());
        }
    }

    public class GetTheMainDepartmentsInTheStore : IFetchAn<IEnumerable<DepartmentDisplayItem>>
    {
        public IEnumerable<DepartmentDisplayItem> run_using(IContainRequestDetails request)
        {
            return new StubStoreCatalog().get_the_main_departments_in_the_store();
        }
    }
}