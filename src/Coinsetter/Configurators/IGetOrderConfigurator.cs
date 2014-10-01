
namespace Coinsetter.Configurators {
    public interface IGetOrderConfigurator {
        IGetOrderConfigurator OrderUuid(string value);
        
    }

    internal class GetOrderConfigurator : IGetOrderConfigurator {
        private GetOrderSettings _settings = new GetOrderSettings();
        public IGetOrderConfigurator OrderUuid(string value) {
            _settings.OrderUuid = value;
            return this;
        }

        public GetOrderSettings Build() {
            return _settings;
        }
    }

    internal class GetOrderSettings {
        public string OrderUuid { get; set; }
    }
}
