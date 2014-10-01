using Coinsetter.Json;
using Newtonsoft.Json;
using System;

namespace Coinsetter.Models {
    public class Quote {
        [JsonProperty("Price")]
        public double Price { get; set; }

        [JsonProperty("Size")]
        public double Size { get; set; }

        [JsonProperty("ExchangeID")]
        public string Exchange { get; set; }

        [JsonProperty("timeStamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTimeOffset Datetime { get; set; }

        public override string ToString() {
            return (new { Datetime, Price, Size, Exchange }).ToString();
        }
    }
}
