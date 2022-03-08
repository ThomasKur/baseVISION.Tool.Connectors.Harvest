using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class Project
    {
        private long? _ClientId;
        [JsonProperty("id")]
        public long? Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("client_id")]
        public long? ClientId
        {
            get
            {
                if (this.Client != null && this.Client.Id != null)
                {
                    return this.Client.Id;
                }
                else
                {
                    return _ClientId;
                }
            }
            set { _ClientId = value; }
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("is_active")]
        public bool? IsActive { get; set; }

        [JsonProperty("bill_by")]
        public BillBy BillBy { get; set; }

        [JsonProperty("budget")]
        public decimal? Budget { get; set; }

        [JsonProperty("budget_by")]
        public BudgetBy BudgetBy { get; set; }

        [JsonProperty("notify_when_over_budget")]
        public bool? NotifyWhenOverBudget { get; set; }

        [JsonProperty("over_budget_notification_percentage")]
        public decimal? OverBudgetNotificationPercentage { get; set; }

        [JsonProperty("over_budget_notification_date")]
        public DateTimeOffset? OverBudgetNotificationDate { get; set; }

        [JsonProperty("show_budget_to_all")]
        public bool? ShowBudgetToAll { get; set; }

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
        [JsonProperty("starts_on")]
        public DateTimeOffset? StartsOn { get; set; }

        [JsonProperty("ends_on")]
        public DateTimeOffset? EndsOn { get; set; }

        [JsonProperty("is_billable")]
        public bool IsBillable { get; set; }

        [JsonProperty("is_fixed_fee")]
        public bool? IsFixedFee { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("client")]
        public LookupObject Client { get; set; }
        public virtual bool ShouldSerializeClient()
        {
            return false;
        }
        [JsonProperty("cost_budget")]
        public decimal? CostBudget { get; set; }

        [JsonProperty("cost_budget_include_expenses")]
        public bool? CostBudgetIncludeExpenses { get; set; }

        [JsonProperty("hourly_rate")]
        public decimal? HourlyRate { get; set; }

        [JsonProperty("fee")]
        public decimal? Fee { get; set; }
    }
}
