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
        public ResultTasks List(int page = 1, bool? isActive = null, DateTime? updatedSince = null)
        {
            RestRequest r = new RestRequest("{module}", Method.GET);
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
            r.JsonSerializer = client.serializer;
            return client.Execute<ResultTasks>(r);
        }
        public Task Get(long id)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.GET);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", id);
            r.JsonSerializer = client.serializer;
            return client.Execute<Task>(r);
        }
        public Task Add(Task entity)
        {
            RestRequest r = new RestRequest("{module}" , Method.POST);

            r.JsonSerializer = client.serializer; r.AddJsonBody(entity);
            
            return client.Execute<Task>(r);
        }
        public Task Update(Task entity)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.PATCH);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", entity.Id);
            r.JsonSerializer = client.serializer;
            r.AddJsonBody(entity);
            
            return client.Execute<Task>(r);
        }
        public void Delete(long id)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.DELETE);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", id);
            r.JsonSerializer = client.serializer;
            client.Execute(r);
        }
    }
}
