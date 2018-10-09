using baseVISION.Tool.Connectors.Harvest.Contracts;
using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest
{
    public class ModuleProjects
    {
        HarvestClient client = null;
        const string module = "projects";
        public ModuleProjects(HarvestClient client)
        {
            this.client = client;
        }
        public ResultProjects List(int page = 1, bool? isActive = null, long? clientid = null, DateTime? updatedSince = null)
        {
            RestRequest r = new RestRequest("{module}", Method.GET);
            r.AddQueryParameter("page", page.ToString());
            r.AddUrlSegment("module", module);
            if (isActive.HasValue)
            {
                r.AddQueryParameter("is_active", isActive.Value.ToString().ToLower());
            }
            if (updatedSince.HasValue)
            {
                r.AddQueryParameter("updated_since", updatedSince.Value.ToString(client.HarvestDateTimeFormat));
            }
            if (clientid.HasValue)
            {
                r.AddQueryParameter("client_id", clientid.Value.ToString());
            }
            r.JsonSerializer = client.serializer;
            return client.Execute<ResultProjects>(r);
        }
        public Project Get(long id)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.GET);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            return client.Execute<Project>(r);
        }
        public Project Add(Project entity)
        {
            RestRequest r = new RestRequest("{module}", Method.POST);
            r.AddUrlSegment("module", module);

            r.JsonSerializer = client.serializer; r.AddJsonBody(entity);
            
            return client.Execute<Project>(r);
        }
        public Project Update(Project entity)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.PATCH);
            r.AddUrlSegment("id", entity.Id);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            r.AddJsonBody(entity);
            
            return client.Execute<Project>(r);
        }
        public void Delete(long id)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.DELETE);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            client.Execute(r);
        }
    }
}
