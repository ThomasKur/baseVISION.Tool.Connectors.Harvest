using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baseVISION.Tool.Connectors.Harvest
{
    public partial class HarvestClient
    {
        private string accountId = null;
        private string personalAccessToken = null;
        private NewtonsoftJsonSerializer serializer = null;
        private IRestClient restDataClient = null;
        public readonly string HarvestDateTimeFormat = "yyyy-MM-ddThh:mm:ssZ";
        public readonly string HarvestDateFormat = "yyyy-MM-dd";

        public event EventHandler<RetryWarningEventArgs> RetryWarning;

        public HarvestClient(string accountId, string personalAccessToken, string url = "https://api.harvestapp.com/v2")
        {
            this.accountId = accountId;
            this.personalAccessToken = personalAccessToken;
            serializer = NewtonsoftJsonSerializer.Default;
            restDataClient = new RestClient(url, configureSerialization: s => s.UseSerializer(() => new NewtonsoftJsonSerializer()));
        /*    restDataClient.AddHandler("application/json", serializer);
            restDataClient.AddHandler("text/json", serializer);
            restDataClient.AddHandler("text/x-json", serializer);
            restDataClient.AddHandler("text/javascript", serializer);
            restDataClient.AddHandler("*+json", serializer);*/

            restDataClient.AddDefaultHeader("Authorization", "Bearer  " + this.personalAccessToken);
            restDataClient.AddDefaultHeader("Harvest-Account-Id", this.accountId);
            Clients = new ModuleClients(this);
            Contacts = new ModuleContacts(this);
            Projects = new ModuleProjects(this);
            Estimates = new ModuleEstimates(this);
            Projects = new ModuleProjects(this);
            Tasks = new ModuleTasks(this);
            TaskAssignments = new ModuleTaskAssignments(this);
            ProjectAssignments = new ModuleProjectAssignments(this);
            Users = new ModuleUsers(this);
            TimeEntries = new ModuleTimeEntries(this);
        }
        internal T Execute<T>(RestRequest request, int maxRetries = 0) where T : new()
        {
            EnsureRequestHeaders(request);
            var retryCount = 0;
            while (true)
            {
                System.Threading.Tasks.Task<RestResponse<T>> responseTask = restDataClient.ExecuteAsync<T>(request);
                responseTask.Wait();
                RestResponse<T> response = responseTask.Result;

                if (TryGetRetryDelay(response, retryCount, maxRetries, out var waitTime))
                {
                    retryCount++;
                    System.Threading.Tasks.Task.Delay(waitTime).Wait();
                    continue;
                }

                ResponseErrorCheck(response);
                return response.Data;
            }
        }
        internal void Execute(RestRequest request, int maxRetries = 0)
        {
            EnsureRequestHeaders(request);
            var retryCount = 0;
            while (true)
            {
                System.Threading.Tasks.Task<RestResponse> responseTask = restDataClient.ExecuteAsync(request);
                responseTask.Wait();
                RestResponse response = responseTask.Result;

                if (TryGetRetryDelay(response, retryCount, maxRetries, out var waitTime))
                {
                    retryCount++;
                    System.Threading.Tasks.Task.Delay(waitTime).Wait();
                    continue;
                }

                ResponseErrorCheck(response);
                return;
            }
        }

        private static void EnsureRequestHeaders(RestRequest request)
        {
            if (request.Method != Method.Get)
            {
                request.AddHeader("Content-Type", "application/json");
            }

            request.AddHeader("Accept", "application/json");
        }

        private bool TryGetRetryDelay(RestResponseBase response, int retryCount, int maxRetries, out TimeSpan waitTime)
        {
            waitTime = default;
            if (maxRetries <= 0 || retryCount >= maxRetries)
            {
                return false;
            }

            if ((int)response.StatusCode != 429)
            {
                return false;
            }

            waitTime = GetRetryAfterDelay(response);
            OnRetryWarning(new RetryWarningEventArgs(response, retryCount + 1, maxRetries, waitTime));
            return true;
        }

        private static TimeSpan GetRetryAfterDelay(RestResponseBase response)
        {
            const int defaultWaitSeconds = 60;
            var retryHeader = response.Headers?.FirstOrDefault(h => string.Equals(h.Name, "Retry-After", StringComparison.OrdinalIgnoreCase));
            if (retryHeader?.Value != null)
            {
                var valueText = retryHeader.Value.ToString();
                if (int.TryParse(valueText, NumberStyles.Integer, CultureInfo.InvariantCulture, out var seconds))
                {
                    return TimeSpan.FromSeconds(Math.Max(seconds, 1));
                }

                if (DateTimeOffset.TryParse(valueText, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out var date))
                {
                    var delta = date - DateTimeOffset.UtcNow;
                    if (delta > TimeSpan.Zero)
                    {
                        return delta;
                    }
                }
            }

            return TimeSpan.FromSeconds(defaultWaitSeconds);
        }

        protected virtual void OnRetryWarning(RetryWarningEventArgs args)
        {
            RetryWarning?.Invoke(this, args);
        }

        public ModuleClients Clients { get; private set; }
        public ModuleContacts Contacts { get; private set; }
        public ModuleProjects Projects { get; private set; }
        public ModuleEstimates Estimates { get; private set; }
        public ModuleTasks Tasks { get; private set; }
        public ModuleTaskAssignments TaskAssignments { get; private set; }
        public ModuleProjectAssignments ProjectAssignments { get; private set; }
        public ModuleTimeEntries TimeEntries { get; private set; }
        public ModuleUsers Users { get; private set; }
    }

    public class RetryWarningEventArgs : EventArgs
    {
        public RetryWarningEventArgs(RestResponseBase response, int retryNumber, int maxRetries, TimeSpan delay)
        {
            Response = response;
            RetryNumber = retryNumber;
            MaxRetries = maxRetries;
            Delay = delay;
            StatusCode = (int)response.StatusCode;
            Resource = response.Request?.Resource ?? string.Empty;
            RetryAfterHeader = RetryAfterValue(response);
        }

        public RestResponseBase Response { get; }
        public int RetryNumber { get; }
        public int MaxRetries { get; }
        public TimeSpan Delay { get; }
        public int StatusCode { get; }
        public string Resource { get; }
        public string RetryAfterHeader { get; }

        private static string RetryAfterValue(RestResponseBase response)
        {
            var header = response.Headers?.FirstOrDefault(h => string.Equals(h.Name, "Retry-After", StringComparison.OrdinalIgnoreCase));
            return header?.Value?.ToString() ?? string.Empty;
        }
    }
}
