using Newtonsoft.Json;

namespace Coinsetter.Models {
    public class Ticker {
        private Quote _bid = new Quote();
        private Quote _ask = new Quote();
        private Quote _last = new Quote();

        [JsonProperty("Bid")]
        public Quote Bid { get { return _bid; } }

        [JsonProperty("Ask")]
        public Quote Ask { get { return _ask; } }

        [JsonProperty("Last")]
        public Quote Last { get { return _last; } }

        public override string ToString() {
            return (new { Bid, Ask, Last }).ToString();
        }       
    }
}
