using Coinsetter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coinsetter.Json {
    internal class PositionsConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Positions).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jobject = JObject.Load(reader);
            return jobject.SelectToken(".positionList").ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}