namespace app.web.core
{
    public class RequestProcessor : IProcessOneRequest
    {
        RequestMatch_Behaviour request_specification;
        ISupportAFeature the_feature;

        public RequestProcessor(RequestMatch_Behaviour request_specification, ISupportAFeature the_feature)
        {
            this.request_specification = request_specification;
            this.the_feature = the_feature;
        }

        public void process(IContainRequestDetails the_request)
        {
            the_feature.process(the_request);
        }

        public bool can_process(IContainRequestDetails request)
        {
            return request_specification(request);
        }
    }
}