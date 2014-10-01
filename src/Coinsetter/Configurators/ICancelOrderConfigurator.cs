using Coinsetter.Models;

namespace Coinsetter.Configurators {
    public interface  ICancelOrderConfigurator {
        ICancelOrderConfigurator OrderUuid(string value);
    }

    internal class CancelOrderConfigurator : ICancelOrderConfigurator {
        private Cancel _cancel = new Cancel();
        public ICancelOrderConfigurator OrderUuid(string value) {
            _cancel.OrderUuid = value;
            return this;
        }

        public Cancel Build() {
            return _cancel;
        }
    }
}
