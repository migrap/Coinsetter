using Coinsetter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coinsetter.Json {
    internal class AccountsConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Accounts) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jobject = JObject.Load(reader);
            return jobject.SelectToken(".accountList").ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}