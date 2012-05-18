using System.Collections;
using System.Collections.Generic;
using app.infrastructure.containers;
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
                                     new ViewA<IEnumerable<DepartmentDisplayItem>>(Container.fetch.an<IFetchAn<IEnumerable<DepartmentDisplayItem>>>(), 
                                         Container.fetch.an<IDisplayInformation>())) ; 
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