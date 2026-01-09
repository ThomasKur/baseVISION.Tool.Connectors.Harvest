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
        public ResultContacts List(int page = 1, bool? isActive = null, long? clientId = null, DateTime? updatedSince = null, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("{module}", Method.Get);
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

            return client.Execute<ResultContacts>(r, maxRetries);
        }
        public Contact Get(long id, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.Get);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", id);

            return client.Execute<Contact>(r, maxRetries);
        }
        public Contact Add(Contact entity, int maxRetries = 0)
        {
            RestRequest r = new RestRequest("{module}", Method.Post);
            r.AddUrlSegment("module", module);
            r.AddJsonBody(entity);

            return client.Execute<Contact>(r, maxRetries);
        }
        public Contact Update(Contact entity, int maxRetries = 0)
        {
            if (entity.Id.HasValue)
            {
                RestRequest r = new RestRequest("{module}/{id}", Method.Patch);
                r.AddUrlSegment("module", module);
                r.AddUrlSegment("id", entity.Id.Value);
                r.AddJsonBody(entity);

                return client.Execute<Contact>(r, maxRetries);
            }

            throw new Exception("Id of object must be specified.");
        }
        public void Delete(long id)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.Delete);
            r.AddUrlSegment("id", id);
            r.AddUrlSegment("module", module);

            client.Execute<Contact>(r);
        }
    }
}
