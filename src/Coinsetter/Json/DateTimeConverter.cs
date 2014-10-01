using Newtonsoft.Json;
using System;

namespace Coinsetter.Json {
    internal class DateTimeConverter : JsonConverter {
        private static readonly DateTimeOffset Epcoh = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        public override bool CanConvert(Type objectType) {
            return typeof(DateTimeOffset) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Integer) {
                return Epcoh.AddMilliseconds((long)reader.Value);
            } else {
                return DateTimeOffset.ParseExact(reader.Value as string, "dd/MM/yyyy HH:mm:ss.fff", null);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
