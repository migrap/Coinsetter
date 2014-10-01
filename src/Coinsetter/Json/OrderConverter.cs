using Coinsetter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Coinsetter.Json {
    internal class OrderConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Order) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jobject = JObject.Load(reader);
            return jobject.ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var order = value as Order;
            var content = new {
                accountUuid = order.AccountUuid,
                customerUuid = order.CustomerUuid,
                orderType = order.OrderType.ToString(),
                requestedQuantity = order.Quantity,
                requestedPrice = order.Price,
                side = order.Side.ToString(),
                symbol = order.Symbol,
                routingMethod = order.RoutingMethod,
            };

            serializer.Serialize(writer, content);
        }
    }
}
