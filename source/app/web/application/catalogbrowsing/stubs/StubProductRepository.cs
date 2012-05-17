using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
    public class StubProductRepository : IFindProducts
    {
        public IEnumerable<ProductDisplayItem> get_the_products_in(DepartmentSelection the_selected_department)
        {
            return Enumerable.Range(1, 20).Select(x => new ProductDisplayItem() {name = x.ToString("Product 0")});
        }
    }
}