using Newtonsoft.Json;

namespace Coinsetter.Models {
    public class Cancel {
        [JsonProperty("UUID")]
        public string OrderUuid { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("requestStatus")]
        public string Status { get; set; }

        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }
    }
}
