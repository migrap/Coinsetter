using Coinsetter.Patterns;
using Newtonsoft.Json;
using System;

namespace Coinsetter.Json {
    internal class SideConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Side) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            return (reader.Value as string).MatchWithResult<Side,string>()
                .With(x => x.Equals("buy", StringComparison.InvariantCultureIgnoreCase), Side.Buy)
                .With(x => x.Equals("sell", StringComparison.InvariantCultureIgnoreCase), Side.Sell)
                .Do();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {            
        }
    }
}
