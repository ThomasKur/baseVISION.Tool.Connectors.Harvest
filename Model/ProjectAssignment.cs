using baseVISION.Tool.Connectors.Harvest.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class ProjectAssignment : IHarvestEntity
    {
        private long? _UserId;

        [JsonProperty("id")]
        public long? Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("is_project_manager")]
        public bool IsProjectManager { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("budget")]
        public decimal? Budget { get; set; }

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
        [JsonProperty("hourly_rate")]
        public decimal? HourlyRate { get; set; }

        [JsonProperty("project")]
        public LookupObject Project { get; set; }

        public virtual bool ShouldSerializeProject()
        {
            return false;
        }
        [JsonProperty("client")]
        public LookupObject Client { get; set; }

        public virtual bool ShouldSerializeClient()
        {
            return false;
        }
        [JsonProperty("user")]
        public LookupObject User { get; set; }
        [JsonProperty("user_id")]
        public long? UserId
        {
            get
            {
                if (this.User != null && this.User.Id != null)
                {
                    return this.User.Id;
                }
                else
                {
                    return _UserId;
                }
            }
            set { _UserId = value; }
        }
        public virtual bool ShouldSerializeUser()
        {
            return false;
        }
        [JsonProperty("task_assignments")]
        public TaskAssignment[] TaskAssignments { get; set; }
    }
}
