using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
    public interface IFindProducts
    {        
        IEnumerable<ProductDisplayItem> get_the_products_in(ViewTheProductsInADepartmentRequest request);
    }
}