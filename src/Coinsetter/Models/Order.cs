using Coinsetter.Json;
using Newtonsoft.Json;
using System;

namespace Coinsetter.Models {
    public class Order {
        [JsonProperty("uuid")]
        public string OrderUuid { get; set; }

        [JsonProperty("customerUuid")]
        public string CustomerUuid { get; set; }

        [JsonProperty("accountUuid")]
        public string AccountUuid { get; set; }

        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("stage")]
        [JsonConverter(typeof(StageConverter))]
        public Stage Stage { get; set; }

        [JsonProperty("orderType")]
        [JsonConverter(typeof(OrderTypeConverter))]
        public OrderType OrderType { get; set; }

        [JsonProperty("side")]
        [JsonConverter(typeof(SideConverter))]
        public Side Side { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("requestedQuantity")]
        public double Quantity { get; set; }

        [JsonProperty("filledQuantity")]
        public double Filled { get; set; }

        [JsonProperty("openQuantity")]
        public double Open { get; set; }

        [JsonProperty("requestedPrice")]
        public double Price { get; set; }

        [JsonProperty("costBasis")]
        public double CostBasis { get; set; }

        [JsonProperty("commission")]
        public double Commission { get; set; }
        
        [JsonProperty("routingMethod")]        
        public int RoutingMethod { get; set; }

        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTimeOffset Created { get; set; }

        public override string ToString() {
            return (new { OrderUuid, Stage, Created, Symbol, Side, Quantity, Filled, Open, Price, CostBasis, Commission = Commission.ToString("N6") }).ToString();
        }
        
    }
}
