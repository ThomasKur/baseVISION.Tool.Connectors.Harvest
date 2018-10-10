using baseVISION.Tool.Connectors.Harvest.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class Client : IHarvestEntity
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("name")]
        public string Name { get; set; }



        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        public virtual bool ShouldSerializeCreatedAt()
        {
            return false;
        }
        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual bool ShouldSerializeUpdatedAt()
        {
            return false;
        }
        [JsonProperty("currency")]
        public Currency Currency { get; set; }
    }
}
