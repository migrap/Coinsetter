
namespace Coinsetter {
    public class OrderType {
        private static readonly OrderType _limit = new OrderType("LIMIT");
        private static readonly OrderType _market = new OrderType("MARKET");

        private string _value;
        private OrderType(string value) {
            _value = value;
        }

        public static OrderType Limit {
            get { return _limit; }
        }

        public static OrderType Market {
            get { return _market; }
        }

        public override string ToString() {
            return _value;
        }
    }
}
