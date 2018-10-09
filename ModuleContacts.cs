using baseVISION.Tool.Connectors.Harvest.Contracts;
using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest
{
    public class ModuleContacts
    {
        HarvestClient client = null;
        const string module = "contacts";
        public ModuleContacts(HarvestClient client)
        {
            this.client = client;

        }
        public ResultContacts List(int page = 1, bool? isActive = null, long? clientId = null, DateTime? updatedSince = null)
        {
            RestRequest r = new RestRequest("{module}", Method.GET);
            r.AddUrlSegment("module", module);
            r.AddQueryParameter("page", page.ToString());

            if (isActive.HasValue)
            {
                r.AddQueryParameter("is_active", isActive.Value.ToString().ToLower());
            }
            if (clientId.HasValue)
            {
                r.AddQueryParameter("client_id", clientId.Value.ToString());
            }
            if (updatedSince.HasValue)
            {
                r.AddQueryParameter("updated_since", updatedSince.Value.ToString(client.HarvestDateTimeFormat));
            }
            r.JsonSerializer = client.serializer;
            return client.Execute<ResultContacts>(r);
        }
        public Contact Get(long id)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.GET);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", id);
            r.JsonSerializer = client.serializer;
            return client.Execute<Contact>(r);
        }
        public Contact Add(Contact entity)
        {
            RestRequest r = new RestRequest("{module}" , Method.POST);
            r.AddUrlSegment("module", module);

            r.JsonSerializer = client.serializer; r.AddJsonBody(entity);
            
            return client.Execute<Contact>(r);
        }
        public Contact Update(Contact entity)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.PATCH);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", entity.Id);
            r.JsonSerializer = client.serializer;
            r.AddJsonBody(entity);
            
            return client.Execute<Contact>(r);
        }
        public void Delete(long id)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.DELETE);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("module", module);
            r.JsonSerializer = client.serializer;
            client.Execute<Contact>(r);
        }
    }
}
