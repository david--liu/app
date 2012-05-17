using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

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
            yield return new RequestProcessor(x => true, new ViewTheDepartmentsInADepartment());
        }
    }
}