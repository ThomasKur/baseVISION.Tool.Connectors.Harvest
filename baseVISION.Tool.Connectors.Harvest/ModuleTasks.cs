using baseVISION.Tool.Connectors.Harvest.Contracts;
using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest
{
    public class ModuleTasks
    {
        HarvestClient client = null;
        const string module = "tasks";
        public ModuleTasks(HarvestClient client)
        {
            this.client = client;
        }
        public ResultTasks List(int page = 1, bool? isActive = null, DateTime? updatedSince = null, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("{module}", Method.Get);
            r.AddUrlSegment("module", module);
            r.AddQueryParameter("page", page.ToString());

            if (isActive.HasValue)
            {
                r.AddQueryParameter("is_active", isActive.Value.ToString().ToLower());
            }
            if (updatedSince.HasValue)
            {
                r.AddQueryParameter("updated_since", updatedSince.Value.ToString(client.HarvestDateTimeFormat));
            }

            return client.Execute<ResultTasks>(r, maxRetries);
        }
        public Task Get(long id, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.Get);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", id);

            return client.Execute<Task>(r, maxRetries);
        }
        public Task Add(Task entity, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("{module}", Method.Post);
            r.AddJsonBody(entity);

            return client.Execute<Task>(r, maxRetries);
        }
        public Task Update(Task entity, int maxRetries = 0)
        {
            if (entity.Id.HasValue)
            {
                RestRequest r = new RestRequest("{module}/{id}", Method.Patch);
                r.AddUrlSegment("module", module);
                r.AddUrlSegment("id", entity.Id.Value);
                r.AddJsonBody(entity);

                return client.Execute<Task>(r, maxRetries);
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
