
namespace Coinsetter.Configurators {
    public interface IGetOrdersConfigurator {
        IGetOrdersConfigurator AccountUuid(string value);
        IGetOrdersConfigurator View(View value);
    }

    internal class GetOrdersConfigurator : IGetOrdersConfigurator {
        private GetOrdersSettings _settings = new GetOrdersSettings();
        public IGetOrdersConfigurator AccountUuid(string value) {
            _settings.AccountUuid = value;
            return this;
        }

        public IGetOrdersConfigurator View(View value) {
            _settings.View = value;
            return this;
        }

        public GetOrdersSettings Build() {
            return _settings;
        }
    }

    internal class GetOrdersSettings {
        public string AccountUuid { get; set; }
        public View View { get; set; }
    }
}
