using baseVISION.Tool.Connectors.Harvest.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class TimeEntry : IHarvestEntity
    {
        private long? _TaskId;
        private long? _UserId;
        private long? _ProjectId;
        [JsonProperty("id")]
        public long? Id { get; set; }
        public bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("spent_date")]
        public DateTimeOffset? SpentDate { get; set; }

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
        public bool ShouldSerializeUser()
        {
            return false;
        }
        [JsonProperty("client")]
        public LookupObject Client { get; set; }
        public bool ShouldSerializeClient()
        {
            return false;
        }
        [JsonProperty("project")]
        public LookupObject Project { get; set; }
        [JsonProperty("project_id")]
        public long? ProjectId
        {
            get
            {
                if (this.Project != null && this.Project.Id != null)
                {
                    return this.Project.Id;
                }
                else
                {
                    return _ProjectId;
                }
            }
            set { _ProjectId = value; }
        }
        public bool ShouldSerializeProject()
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
        public bool ShouldSerializeTask()
        {
            return false;
        }
        [JsonProperty("user_assignment")]
        public ProjectAssignment UserAssignment { get; set; }
        public bool ShouldSerializeUserAssignment()
        {
            return false;
        }
        [JsonProperty("task_assignment")]
        public TaskAssignment TaskAssignment { get; set; }
        public bool ShouldSerializeTaskAssignment()
        {
            return false;
        }
        [JsonProperty("hours")]
        public decimal Hours { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

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
        [JsonProperty("is_locked")]
        public bool IsLocked { get; set; }
        public bool ShouldSerializeIsLocked()
        {
            return false;
        }
        [JsonProperty("locked_reason")]
        public string LockedReason { get; set; }
        public bool ShouldSerializeLockedReason()
        {
            return false;
        }
        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }
        public bool ShouldSerializeIsClosed()
        {
            return false;
        }
        [JsonProperty("is_billed")]
        public bool IsBilled { get; set; }
        public bool ShouldSerializeIsBilled()
        {
            return false;
        }
        [JsonProperty("timer_started_at")]
        public DateTimeOffset? TimerStartedAt { get; set; }
        public bool ShouldSerializeTimerStartedAt()
        {
            return false;
        }
        [JsonProperty("started_time")]
        public DateTimeOffset? StartedTime { get; set; }
        public bool ShouldSerializeStartedTime()
        {
            return false;
        }
        [JsonProperty("ended_time")]
        public DateTimeOffset? EndedTime { get; set; }
        public bool ShouldSerializeEndedTime()
        {
            return false;
        }
        [JsonProperty("is_running")]
        public bool IsRunning { get; set; }
        public bool ShouldSerializeIsRunning()
        {
            return false;
        }

        [JsonProperty("billable")]
        public bool Billable { get; set; }

        [JsonProperty("budgeted")]
        public bool Budgeted { get; set; }

        [JsonProperty("billable_rate")]
        public decimal? BillableRate { get; set; }

        [JsonProperty("cost_rate")]
        public decimal? CostRate { get; set; }
    }
}
