using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinsetter.Json {
    internal class LevelPriceConverter : JsonConverter {
        private static readonly double Divisor = 100.00d;
        public override bool CanConvert(Type objectType) {
            return typeof(DateTimeOffset) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Integer) {
                return (((double)reader.Value) / (Divisor));
            }
            throw new InvalidOperationException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
