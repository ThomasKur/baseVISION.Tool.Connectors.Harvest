using baseVISION.Tool.Connectors.Harvest.Contracts;
using baseVISION.Tool.Connectors.Harvest.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest
{
    public class ModuleEstimates
    {
        HarvestClient client = null;
        const string module = "estimates";
        public ModuleEstimates(HarvestClient client)
        {
            this.client = client;
        }
        public ResultEstimates List(int page = 1, long? clientId = null, EstimateState? state = null, DateTime? updatedSince = null)
        {
            RestRequest r = new RestRequest("{module}", Method.Get);
            r.AddUrlSegment("module", module);
            r.AddQueryParameter("page", page.ToString());

            if (state.HasValue)
            {
                r.AddQueryParameter("state", state.Value.ToString());
            }
            if (clientId.HasValue)
            {
                r.AddQueryParameter("client_id", clientId.Value.ToString());
            }
            if (updatedSince.HasValue)
            {
                r.AddQueryParameter("updated_since", updatedSince.Value.ToString(client.HarvestDateTimeFormat));
            }
            
            return client.Execute<ResultEstimates>(r);
        }
        public Estimate Get(long id)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.Get);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", id);
            
            return client.Execute<Estimate>(r);
        }
        public Estimate Add(Estimate entity)
        {
            RestRequest r = new RestRequest("{module}" , Method.Post);

            
            r.AddJsonBody(entity);
            
            return client.Execute<Estimate>(r);
        }
        public Estimate Update(Estimate entity)
        {
            RestRequest r = new RestRequest("{module}/{id}", Method.Patch);
            r.AddUrlSegment("module", module);
            r.AddUrlSegment("id", entity.Id);
            
            r.AddJsonBody(entity);
            
            return client.Execute<Estimate>(r);
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
