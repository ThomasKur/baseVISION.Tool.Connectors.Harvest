using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("timezone")]
        public HarvestTimezone Timezone { get; set; }

        [JsonProperty("has_access_to_all_future_projects")]
        public bool HasAccessToAllFutureProjects { get; set; }

        [JsonProperty("is_contractor")]
        public bool IsContractor { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("is_project_manager")]
        public bool IsProjectManager { get; set; }

        [JsonProperty("can_see_rates")]
        public bool CanSeeRates { get; set; }

        [JsonProperty("can_create_projects")]
        public bool CanCreateProjects { get; set; }

        [JsonProperty("can_create_invoices")]
        public bool CanCreateInvoices { get; set; }

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
        [JsonProperty("weekly_capacity")]
        public long WeeklyCapacity { get; set; }

        [JsonProperty("default_hourly_rate")]
        public decimal? DefaultHourlyRate { get; set; }

        [JsonProperty("cost_rate")]
        public decimal? CostRate { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
