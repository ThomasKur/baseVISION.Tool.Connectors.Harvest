using RestSharp;

namespace baseVISION.Tool.Connectors.Harvest
{
    public partial class HarvestClient
    {
        internal void ReplaceRestClient(IRestClient restClient)
        {
            restDataClient = restClient;
        }
    }
}
