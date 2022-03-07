using RestSharp;
using System;


namespace baseVISION.Tool.Connectors.Harvest
{
    public partial class HarvestClient
    {
        private void ResponseErrorCheck(RestResponse response)
        {
            switch (response.ResponseStatus)
            {
                case ResponseStatus.Aborted:
                    throw new OperationCanceledException("Aborted requesting " + response.Request.Resource + ".");
                case ResponseStatus.Error:
                    throw response.ErrorException;
                case ResponseStatus.TimedOut:
                    throw new TimeoutException("Timeout(" + response.Request.Timeout + ") reached for requesting " + response.Request.Resource + ".");
                case ResponseStatus.None:
                    break;
                case ResponseStatus.Completed:
                    break;
                default:
                    break;
            }

            
            switch ((int)response.StatusCode)
            {
                case 403:
                    throw new Exception("The object you requested was found but you don’t have authorization to perform your request. Details: " + response.Content);
                case 404:
                    throw new Exception("The object you requested can’t be found. Details: " + response.Content);
                case 422:
                    throw new Exception("There were errors processing your request. Check the response body for additional information. Details: " + response.Content);
                case 429:
                    throw new Exception("Your request has been throttled. Refer to the Rate Limiting section for details. Details: " + response.Content);
                case 500:
                    throw new Exception("There was a server error. Contact support@getharvest.com for help. Details: " + response.Content);
                default:
                    break;
            }
        }
    }
}
