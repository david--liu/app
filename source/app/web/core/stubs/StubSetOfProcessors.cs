using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;
using app.web.core.aspnet;

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
                                     new ViewAPage<IEnumerable<DepartmentDisplayItem>>(
                                         request =>
                                             new StubStoreCatalog().get_the_main_departments_in_the_store()));
            yield return
                new RequestProcessor(x => true,
                                     new ViewAPage<IEnumerable<DepartmentDisplayItem>>(
                                         request =>
                                             new StubStoreCatalog().get_the_departments_in(
                                                 request.map<DepartmentSelection>())));

            yield return
                new RequestProcessor(x => true,
                                     new ViewAPage<IEnumerable<ProductDisplayItem>>(
                                         request =>
                                             new StubStoreCatalog().get_the_products_in(
                                                 request.map<ViewTheProductsInADepartmentRequest>())));

            yield return new RequestProcessor(x => true, new ViewTheProductsInADepartment());

            yield return new RequestProcessor(x => true, new ViewTheProductsInADepartment());
            yield return new RequestProcessor(x => true, new ViewTheMainDepartmentsInTheStore());
            yield return new RequestProcessor(x => true, new ViewTheDepartmentsInADepartment());
        }
    }
}