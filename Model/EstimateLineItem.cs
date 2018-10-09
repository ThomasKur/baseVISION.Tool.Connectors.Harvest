using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{
    public class EstimateLineItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        public bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("unit_price")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        public bool ShouldSerializeAmount()
        {
            return false;
        }
        [JsonProperty("taxed")]
        public bool Taxed { get; set; }

        [JsonProperty("taxed2")]
        public bool Taxed2 { get; set; }
    }
}
