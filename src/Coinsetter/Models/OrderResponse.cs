using Newtonsoft.Json;

namespace Coinsetter.Models {
    public class OrderResponse {
        [JsonProperty("uuid")]
        public string OrderUuid { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("requestStatus")]
        public string Status { get; set; }

        [JsonProperty("orderNumber")]
        public string OrderNumber{get;set;}

        public override string ToString() {
            return (new { OrderUuid, Message, Status, OrderNumber }).ToString();
        }
    }
}
