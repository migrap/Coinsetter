using Newtonsoft.Json;
using System;

namespace Coinsetter.Models {
    public class Last {
        public double Price { get; set; }
        public double Size { get; set; }

        [JsonProperty("ExchangeID")]
        public string Exchange { get; set; }

        private DateTimeOffset _datetime = DateTimeOffset.UtcNow;
        public DateTimeOffset Datetime { get { return _datetime; } }
    }
}
