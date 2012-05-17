namespace app.web.core.aspnet
{
    public class WebFormDisplayEngine : IDisplayInformation
    {
        readonly IContainDataForClient containDataForClient;

        public void display<ReportModel>(ReportModel model)
        {
            containDataForClient.store(model);
        }

        public WebFormDisplayEngine(IContainDataForClient containDataForClient)
        {
            this.containDataForClient = containDataForClient;
        }

        
    }
}