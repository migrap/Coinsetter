using Coinsetter.Json;
using System.Net.Http.Formatting;

namespace Coinsetter.Net.Http.Formatting {
    internal class CoinsetterMediaTypeFormatter : JsonMediaTypeFormatter {
        public CoinsetterMediaTypeFormatter() {            
            SerializerSettings.Converters.Add(new AccountsConverter());
            SerializerSettings.Converters.Add(new DateTimeConverter());
            SerializerSettings.Converters.Add(new DepthConverter());
            SerializerSettings.Converters.Add(new OrderConverter());
            SerializerSettings.Converters.Add(new OrdersConverter());
            SerializerSettings.Converters.Add(new OrderTypeConverter());
            SerializerSettings.Converters.Add(new PositionsConverter());
            SerializerSettings.Converters.Add(new SideConverter());
            SerializerSettings.Converters.Add(new StageConverter());
            SerializerSettings.Converters.Add(new TransactionsConverter());
            SerializerSettings.Converters.Add(new LevelsConverter());
            SerializerSettings.Converters.Add(new LevelPriceConverter());
        }
    }
}
