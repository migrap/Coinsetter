using Newtonsoft.Json;

namespace Coinsetter.Models {
    public class Session {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("customerUuid")]
        public string CustomerUuid { get; set; }

        [JsonProperty("requestStatus")]
        public string RequestStatus { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("customerPasswordStatus")]
        public string PasswordStatus { get; set; }

        [JsonProperty("customerStatus")]
        public string CustomerStatus { get; set; }
    }
}
