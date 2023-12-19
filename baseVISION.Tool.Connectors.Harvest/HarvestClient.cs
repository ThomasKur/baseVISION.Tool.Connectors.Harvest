using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace baseVISION.Tool.Connectors.Harvest
{
    public partial class HarvestClient
    {
        private string accountId = null;
        private string personalAccessToken = null;
        private NewtonsoftJsonSerializer serializer = null;
        private RestClient restDataClient = null;
        public readonly string HarvestDateTimeFormat = "yyyy-MM-ddThh:mm:ssZ";
        public readonly string HarvestDateFormat = "yyyy-MM-dd";
        public HarvestClient(string accountId, string personalAccessToken,string url = "https://api.harvestapp.com/v2")
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
            restDataClient.AddDefaultHeader("Harvest-Account-Id",this.accountId);
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
        internal T Execute<T>(RestRequest request) where T : new()
        {
            if (request.Method != Method.Get)
            {
                //request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
            }
            request.AddHeader("Accept", "application/json");
            Task<RestResponse<T>> response = restDataClient.ExecuteAsync<T>(request);
            response.Wait();
            ResponseErrorCheck(response.Result);
            return response.Result.Data;
        }
        internal void Execute(RestRequest request)
        {
            if (request.Method != Method.Get) { 
                //request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
            }
            request.AddHeader("Accept", "application/json");
            Task<RestResponse> response = restDataClient.ExecuteAsync(request);
            response.Wait();
            ResponseErrorCheck(response.Result);
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
}
