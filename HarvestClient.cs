using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest
{
    public partial class HarvestClient
    {
        private string accountId = null;
        private string personalAccessToken = null;
        public NewtonsoftJsonSerializer serializer = null;
        public RestClient restDataClient = null;
        public readonly string HarvestDateTimeFormat = "yyyy-MM-ddThh:mm:ssZ";
        public readonly string HarvestDateFormat = "yyyy-MM-dd";
        public HarvestClient(string accountId, string personalAccessToken,string url = "https://api.harvestapp.com/api/v2")
        {
            this.accountId = accountId;
            this.personalAccessToken = personalAccessToken;
            serializer = NewtonsoftJsonSerializer.Default;
            restDataClient = new RestClient(url);
            restDataClient.AddHandler("application/json", serializer);
            restDataClient.AddHandler("text/json", serializer);
            restDataClient.AddHandler("text/x-json", serializer);
            restDataClient.AddHandler("text/javascript", serializer);
            restDataClient.AddHandler("*+json", serializer);

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
            
            request.RequestFormat = DataFormat.Json;

            IRestResponse<T> response = restDataClient.Execute<T>(request);
            ResponseErrorCheck(response);
            return response.Data;
        }
        internal void Execute(RestRequest request)
        {

            request.RequestFormat = DataFormat.Json;

            IRestResponse response = restDataClient.Execute(request);
            ResponseErrorCheck(response);

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
