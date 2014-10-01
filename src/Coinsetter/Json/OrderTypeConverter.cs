using Coinsetter.Patterns;
using Newtonsoft.Json;
using System;

namespace Coinsetter.Json {
    internal class OrderTypeConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(OrderType) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            return (reader.Value as string).MatchWithResult<OrderType, string>()
                .With(x => x.Equals("market", StringComparison.InvariantCultureIgnoreCase), OrderType.Market)
                .With(x => x.Equals("limit", StringComparison.InvariantCultureIgnoreCase), OrderType.Limit)
                .Do();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {            
        }
    }
}