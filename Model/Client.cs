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
        public bool ShouldSerializeId()
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
        public bool ShouldSerializeCreatedAt()
        {
            return false;
        }
        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool ShouldSerializeUpdatedAt()
        {
            return false;
        }
        [JsonProperty("currency")]
        public Currency Currency { get; set; }
    }
}
