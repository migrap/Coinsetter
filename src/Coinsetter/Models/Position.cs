using Coinsetter.Json;
using Newtonsoft.Json;
using System;

namespace Coinsetter.Models {
    public class Position {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("customerUuid")]
        public string CustomerUuid { get; set; }

        [JsonProperty("accountUuid")]
        public string AccountUuid { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("side")]
        [JsonConverter(typeof(SideConverter))]
        public Side Side { get; set; }
        
        [JsonProperty("vwap")]
        public double Vwap { get; set; }

        [JsonProperty("mtm")]
        public double Mtm { get; set; }

        [JsonProperty("mtmPl")]
        public double MtmPl { get; set; }

        [JsonIgnore()]
        public double Amount {
            get { return (Side == Side.Sell) ? -Math.Abs(Quantity) : Math.Abs(Quantity); }
        }

        public override string ToString() {
            return (new { CustomerUuid, AccountUuid, Side, Symbol, Quantity, Vwap, Mtm, MtmPl }).ToString();
        }
    }
}
