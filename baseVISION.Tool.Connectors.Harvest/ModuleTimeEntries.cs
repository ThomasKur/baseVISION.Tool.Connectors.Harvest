using baseVISION.Tool.Connectors.Harvest.Contracts;
using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest
{
    public class ModuleTimeEntries
    {
        HarvestClient client = null;
        const string module = "time_entries";
        public ModuleTimeEntries(HarvestClient client)
        {
            this.client = client;
        }
        public ResultTimeEntries List(int page = 1,long? userId = null,long? projectId = null,long? clientId = null, bool? isBilled = null, bool? isRunning = null, DateTime? updatedSince = null, DateTime? from = null, DateTime? to = null, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("{module}", Method.Get);
            r.AddUrlSegment("module", module);
            r.AddQueryParameter("page", page.ToString());
            if (userId.HasValue)
            {
                r.AddQueryParameter("user_id", userId.Value.ToString());
            }
            if (projectId.HasValue)
            {
                r.AddQueryParameter("project_id", projectId.Value.ToString());
            }
            if (clientId.HasValue)
            {
                r.AddQueryParameter("client_id", clientId.Value.ToString());
            }
            if (isBilled.HasValue)
            {
                r.AddQueryParameter("is_billed", isBilled.Value.ToString().ToLower());
            }
            if (isRunning.HasValue)
            {
                r.AddQueryParameter("is_running", isRunning.Value.ToString().ToLower());
            }
            if (updatedSince.HasValue)
            {
                r.AddQueryParameter("updated_since", updatedSince.Value.ToString(client.HarvestDateTimeFormat));
            }
            if (from.HasValue)
            {
                r.AddQueryParameter("from", from.Value.ToString(client.HarvestDateFormat));
            }
            if (to.HasValue)
            {
                r.AddQueryParameter("to", to.Value.ToString(client.HarvestDateFormat));
            }
            
            return client.Execute<ResultTimeEntries>(r, maxRetries);
        }
        public TimeEntry Get(long id, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.Get);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", id);
            
            return client.Execute<TimeEntry>(r, maxRetries);
        }
        public TimeEntry Add(TimeEntry entity, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("{module}", Method.Post);
            r.AddJsonBody(entity);
            
            return client.Execute<TimeEntry>(r, maxRetries);
        }
        public TimeEntry Update(TimeEntry entity, int maxRetries = 0)
        {

            if (entity.Id.HasValue)
            {
                RestRequest r = new RestRequest("{module}/{id}", Method.Patch);
                r.AddUrlSegment("module", module);
                r.AddUrlSegment("id", entity.Id.Value);
                
                r.AddJsonBody(entity);
                
                return client.Execute<TimeEntry>(r, maxRetries);
            }

            throw new Exception("Id of object must be specified.");
        }
        public void Delete(long id)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.Delete);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", id);
            
            client.Execute(r);
        }
    }
}
