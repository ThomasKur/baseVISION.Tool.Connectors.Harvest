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
        public ResultTaskAssignments List(int page = 1, bool? isActive = null, long? projectId = null, DateTime? updatedSince = null, int maxRetries = 0)
        {
            RestRequest r;
            if (projectId.HasValue && projectId.Value != 0)
            {
                r = new RestRequest("/projects/{projectId}/{module}", Method.Get);
                r.AddUrlSegment("projectId", projectId.Value);
            } else
            {
                r = new RestRequest("{module}", Method.Get);
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
            
            return client.Execute<ResultTaskAssignments>(r, maxRetries);
        }
        
        public TaskAssignment Get(long id, long projectId, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("/projects/{projectId}/{module}/{id}", Method.Get);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            
            return client.Execute<TaskAssignment>(r, maxRetries);
        }
        public TaskAssignment Add(TaskAssignment entity, long projectId, int maxRetries = 0)
        {
               
            RestRequest r = new RestRequest("/projects/{projectId}/{module}", Method.Post);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            
            r.AddJsonBody(entity);
            
            return client.Execute<TaskAssignment>(r, maxRetries);
        }
        public TaskAssignment Update(TaskAssignment entity, long projectId, int maxRetries = 0)
        {
            if (entity.Id.HasValue)
            {
                RestRequest r = new RestRequest("/projects/{projectId}/{module}/{id}", Method.Patch);
                r.AddUrlSegment("id", entity.Id.Value);
                r.AddUrlSegment("projectId", projectId);
                r.AddUrlSegment("module", module);
                
                r.AddJsonBody(entity);
                
                return client.Execute<TaskAssignment>(r, maxRetries);
            }

            throw new Exception("Id of object must be specified.");
        }
        public void Delete(long id, long projectId)
        {
            RestRequest r = new RestRequest("/projects/{projectId}/{module}/{id}", Method.Delete);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            
            client.Execute(r);
        }
    }
}
