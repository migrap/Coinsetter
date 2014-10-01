using Coinsetter.Models;

namespace Coinsetter.Configurators {
    public interface IAddOrderConfigurator {
        IAddOrderConfigurator CustomerUuid(string value);
        IAddOrderConfigurator AccountUuid(string value);
        IAddOrderConfigurator Symbol(string value);
        IAddOrderConfigurator Side(Side value);
        IAddOrderConfigurator OrderType(OrderType value);
        IAddOrderConfigurator Quantity(double value);
        IAddOrderConfigurator Price(double value);
    }

    internal class AddOrderConfigurator : IAddOrderConfigurator {
        private Order _order = new Order() { RoutingMethod = 1 };
        public IAddOrderConfigurator CustomerUuid(string value) {
            _order.CustomerUuid = value;
            return this;
        }

        public IAddOrderConfigurator AccountUuid(string value) {
            _order.AccountUuid = value;
            return this;
        }

        public IAddOrderConfigurator Symbol(string value) {
            _order.Symbol = value;
            return this;
        }

        public IAddOrderConfigurator Side(Side value) {
            _order.Side = value;
            return this;
        }

        public IAddOrderConfigurator OrderType(OrderType value) {
            _order.OrderType = value;
            return this;
        }

        public IAddOrderConfigurator Quantity(double value) {
            _order.Quantity = value;
            return this;
        }

        public IAddOrderConfigurator Price(double value) {
            _order.Price = value;
            return this;
        }

        public Order Build() {
            return _order;
        }
    }
}
