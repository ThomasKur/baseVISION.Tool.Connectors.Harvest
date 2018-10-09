using baseVISION.Tool.Connectors.Harvest.Contracts;
using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest
{
    public class ModuleProjectAssignments
    {
        HarvestClient client = null;
        const string module = "project_assignments";
        public ModuleProjectAssignments(HarvestClient client)
        {
            this.client = client;
        }
        public ResultProjectAssignments ListByProject(long projectId, int page = 1,  DateTime? updatedSince = null)
        {
            RestRequest r;
            r = new RestRequest("/projects/{projectId}/{module}", Method.GET);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            r.AddQueryParameter("page", page.ToString());
            if (updatedSince.HasValue)
            {
                r.AddQueryParameter("updated_since", updatedSince.Value.ToString(client.HarvestDateTimeFormat));
            }
            
            r.JsonSerializer = client.serializer;
            return client.Execute<ResultProjectAssignments>(r);
        }
        public ResultProjectAssignments ListByUser(long userId, int page = 1,  DateTime? updatedSince = null)
        {
            RestRequest r;
            
            r = new RestRequest("/users/{userId}/{module}", Method.GET);
            r.AddUrlSegment("userId", userId);
            r.AddUrlSegment("module", module);
            r.AddQueryParameter("page", page.ToString());
            if (updatedSince.HasValue)
            {
                r.AddQueryParameter("updated_since", updatedSince.Value.ToString(client.HarvestDateTimeFormat));
            }
            r.JsonSerializer = client.serializer;
            return client.Execute<ResultProjectAssignments>(r);
        }

        public ProjectAssignment GetByProject(long id, long projectId)
        {
            RestRequest r = new RestRequest("/projects/{projectId}/{module}/{id}", Method.GET);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            return client.Execute<ProjectAssignment>(r);
        }
        public ProjectAssignment GetByUser(long id, long userId)
        {
            RestRequest r = new RestRequest("/users/{projectId}/{module}/{id}", Method.GET);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("projectId", userId);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            return client.Execute<ProjectAssignment>(r);
        }
        public ProjectAssignment Add(ProjectAssignment entity, long projectId)
        {
               
            RestRequest r = new RestRequest("/projects/{projectId}/{module}", Method.POST);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            r.AddJsonBody(entity);
            
            return client.Execute<ProjectAssignment>(r);
        }

        public ProjectAssignment Update(ProjectAssignment entity, long projectId)
        {
            RestRequest r = new RestRequest("/projects/{projectId}/{module}/{id}", Method.PATCH);
            r.AddUrlSegment("id", entity.Id);
            r.AddUrlSegment("projectId", projectId);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            r.AddJsonBody(entity);
            
            return client.Execute<ProjectAssignment>(r);
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
