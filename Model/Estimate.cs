using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class Estimate
    {
        private long? _ClientId;
        [JsonProperty("id")]
        public long Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("client_key")]
        public string ClientKey { get; set; }
        public virtual bool ShouldSerializeClientKey()
        {
            return false;
        }
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("purchase_order")]
        public string PurchaseOrder { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("tax")]
        public decimal? Tax { get; set; }

        [JsonProperty("tax_amount")]
        public decimal? TaxAmount { get; set; }
        public virtual bool ShouldSerializeTaxAmount()
        {
            return false;
        }
        [JsonProperty("tax2")]
        public decimal? Tax2 { get; set; }

        [JsonProperty("tax2_amount")]
        public decimal? Tax2Amount { get; set; }
        public virtual bool ShouldSerializeTax2Amount()
        {
            return false;
        }
        [JsonProperty("discount")]
        public decimal? Discount { get; set; }

        [JsonProperty("discount_amount")]
        public decimal? DiscountAmount { get; set; }
        public virtual bool ShouldSerializeDiscountAmount()
        {
            return false;
        }
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("state")]
        public EstimateState State { get; set; }

        [JsonProperty("issue_date")]
        public DateTimeOffset? IssueDate { get; set; }

        [JsonProperty("sent_at")]
        public DateTimeOffset? SentAt { get; set; }

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
        [JsonProperty("accepted_at")]
        public DateTimeOffset? AcceptedAt { get; set; }
        public virtual bool ShouldSerializeAcceptedAt()
        {
            return false;
        }
        [JsonProperty("declined_at")]
        public DateTimeOffset? DeclinedAt { get; set; }

        [JsonProperty("currency")]
        public Currency Currency { get; set; }
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
        [JsonProperty("client")]
        public Client Client { get; set; }

        [JsonProperty("creator")]
        public Client Creator { get; set; }

        [JsonProperty("line_items")]
        public List<EstimateLineItem> LineItems { get; set; }
    }
}
