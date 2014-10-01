using Coinsetter.Json;
using Newtonsoft.Json;
using System;

namespace Coinsetter.Models {
    public class Account {
        [JsonProperty("accountUuid")]
        public string AccountUuid { get; set; }

        [JsonProperty("customerUuid")]
        public string CustomerUuid { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("denomination")]
        public string Denomination { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("accountBalance")]
        public double AccountBalance { get; set; }

        [JsonProperty("accountClass")]
        public string AccountClass { get; set; }

        [JsonProperty("activeStatus")]
        public string ActiveStatus { get; set; }

        [JsonProperty("approvedMarginRatio")]
        public double MarginRatio { get; set; }

        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("marginBalance")]
        public double MarginBalance { get; set; }

        [JsonProperty("marginUsed")]
        public double MarginUsed { get; set; }        

        [JsonProperty("sellShortPermitted")]
        public bool SellShortPermitted { get; set; }
    }
}
