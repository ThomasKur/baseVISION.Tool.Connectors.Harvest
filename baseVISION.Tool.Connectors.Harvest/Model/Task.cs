using baseVISION.Tool.Connectors.Harvest.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class Task :IHarvestEntity
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("billable_by_default")]
        public bool BillableByDefault { get; set; }

        [JsonProperty("default_hourly_rate")]
        public decimal? DefaultHourlyRate { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

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
    }
}
