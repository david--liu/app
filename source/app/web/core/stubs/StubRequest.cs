using System;

namespace app.web.core.stubs
{
    public class StubRequest : IContainRequestDetails
    {
        public InputModel map<InputModel>()
        {
            return Activator.CreateInstance<InputModel>();
        }
    }
}