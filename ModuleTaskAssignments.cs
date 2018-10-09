using baseVISION.Tool.Connectors.Harvest.Contracts;
using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest
{
    public class ModuleTaskAssignments
    {
        HarvestClient client = null;
        const string module = "task_assignments";
        public ModuleTaskAssignments(HarvestClient client)
        {
            this.client = client;
        }
        public ResultTaskAssignments List(int page = 1, bool? isActive = null, long? projectId = null, DateTime? updatedSince = null)
        {
            RestRequest r;
            if (projectId.HasValue && projectId.Value != 0)
            {
                r = new RestRequest("/projects/{projectId}/{module}", Method.GET);
                r.AddUrlSegment("projectId", projectId);
            } else
            {
                r = new RestRequest("{module}", Method.GET);
            }
            
            r.AddUrlSegment("module", module);
            r.AddQueryParameter("page", page.ToString());
            if (updatedSince.HasValue)
            {
                r.AddQueryParameter("updated_since", updatedSince.Value.ToString(client.HarvestDateTimeFormat));
            }
            if (isActive.HasValue)
            {
                r.AddQueryParameter("is_active", isActive.Value.ToString().ToLower());
            }
            r.JsonSerializer = client.serializer;
            return client.Execute<ResultTaskAssignments>(r);
        }
        
        public TaskAssignment Get(long id, long projectId)
        {
            RestRequest r = new RestRequest("/projects/{projectId}/{module}/{id}", Method.GET);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            return client.Execute<TaskAssignment>(r);
        }
        public TaskAssignment Add(TaskAssignment entity, long projectId)
        {
               
            RestRequest r = new RestRequest("/projects/{projectId}/{module}", Method.POST);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            r.AddJsonBody(entity);
            
            return client.Execute<TaskAssignment>(r);
        }
        public TaskAssignment Update(TaskAssignment entity, long projectId)
        {
            RestRequest r = new RestRequest("/projects/{projectId}/{module}/{id}", Method.PATCH);
            r.AddUrlSegment("id", entity.Id);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            r.AddJsonBody(entity);
            
            return client.Execute<TaskAssignment>(r);
        }
        public void Delete(long id, long projectId)
        {
            RestRequest r = new RestRequest("/projects/{projectId}/{module}/{id}", Method.DELETE);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            client.Execute(r);
        }
    }
}
