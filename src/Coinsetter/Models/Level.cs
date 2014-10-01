using Coinsetter.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinsetter.Models {
    public class Level {
        [JsonProperty("side")]
        [JsonConverter(typeof(SideConverter))]
        public Side Side { get; set; }

        [JsonProperty("level")]
        [JsonConverter(typeof(LevelPriceConverter))]
        public long Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("exchangeId")]
        public string Exchange { get; set; }

        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTimeOffset Timestamp { get; set; }
    }
}
