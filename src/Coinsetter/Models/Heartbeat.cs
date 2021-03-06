﻿using Newtonsoft.Json;

namespace Coinsetter.Models {
    public class Heartbeat {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("requestStatus")]
        public string RequestStatus { get; set; }
    }
}
