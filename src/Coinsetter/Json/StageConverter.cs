using Coinsetter.Patterns;
using Newtonsoft.Json;
using System;

namespace Coinsetter.Json {
    internal class StageConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Stage) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var comparison = StringComparison.InvariantCultureIgnoreCase;
            return (reader.Value as string).MatchWithResult<Stage, string>()
                .With(x => x.Equals("new", comparison), Stage.New)
                .With(x => x.Equals("pending", comparison), Stage.Pending)
                .With(x => x.Equals("open", comparison), Stage.Open)
                .With(x => x.Equals("partial_fill", comparison), Stage.Partial)
                .With(x => x.Equals("expired", comparison), Stage.Expired)
                .With(x => x.Equals("canceled", comparison), Stage.Canceled)
                .With(x => x.Equals("rejected", comparison), Stage.Rejected)
                .With(x => x.Equals("closed", comparison), Stage.Closed)
                .With(x => x.Equals("ext_routed", comparison), Stage.Routed)
                .With(x => x.Equals("working", comparison), Stage.Working)
                .With(x => x.Equals("filled", comparison), Stage.Filled)
                .Do();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {            
        }
    }
}
