using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
    public class StubStoreCatalog : IFindInformationAboutTheStore
    {
        public IEnumerable<DepartmentDisplayItem> get_the_main_departments_in_the_store()
        {
            return Enumerable.Range(1, 100).Select(x => new DepartmentDisplayItem{name = x.ToString("Department 0")});
        }

        public IEnumerable<DepartmentDisplayItem> get_the_departments_in(DepartmentSelection the_selected_department)
        {
            return Enumerable.Range(1, 100).Select(x => new DepartmentDisplayItem{name = x.ToString("Sub Department 0")});
        }
        public IEnumerable<ProductDisplayItem> get_the_products_in(ViewTheProductsInADepartmentRequest the_selected_department)
        {
            return Enumerable.Range(1, 20).Select(x => new ProductDisplayItem {name = x.ToString("Product 0")});
        }
    }
}
