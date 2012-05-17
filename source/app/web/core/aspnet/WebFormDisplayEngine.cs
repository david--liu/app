namespace app.web.core.aspnet
{
    public class WebFormDisplayEngine : IDisplayInformation
    {
        readonly IDataStore dataStore;

        public void display<ReportModel>(ReportModel model)
        {
            dataStore.store(model);
        }

        public WebFormDisplayEngine(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        
    }
}