using baseVISION.Tool.Connectors.Harvest.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class TaskAssignment : IHarvestEntity
    {
        private long? _TaskId;
        [JsonProperty("id")]
        public long? Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("billable")]
        public bool Billable { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        public virtual bool ShouldSerializeCreatedAt()
        {
            return false;
        }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        public virtual bool ShouldSerializeUpdatedAt()
        {
            return false;
        }
        [JsonProperty("hourly_rate")]
        public decimal? HourlyRate { get; set; }

        [JsonProperty("budget")]
        public decimal? Budget { get; set; }

        [JsonProperty("project")]
        public LookupObject Project { get; set; }
        public virtual bool ShouldSerializeProject()
        {
            return false;
        }
        [JsonProperty("task")]
        public LookupObject Task { get; set; }
        [JsonProperty("task_id")]
        public long? TaskId
        {
            get
            {
                if (this.Task != null && this.Task.Id != null)
                {
                    return this.Task.Id;
                }
                else
                {
                    return _TaskId;
                }
            }
            set { _TaskId = value; }
        }
        public virtual bool ShouldSerializeTask()
        {
            return false;
        }
    }
}
