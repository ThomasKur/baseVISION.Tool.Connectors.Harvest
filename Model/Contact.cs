using baseVISION.Tool.Connectors.Harvest.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class Contact : IHarvestEntity
    {
        private long? _ClientId;
        [JsonProperty("id")]
        public long? Id { get; set; }
        public bool ShouldSerializeId()
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

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone_office")]
        public string PhoneOffice { get; set; }

        [JsonProperty("phone_mobile")]
        public string PhoneMobile { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

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
        [JsonProperty("client")]
        public LookupObject Client { get; set; }
        public bool ShouldSerializeClient()
        {
            return false;
        }
    }
}
