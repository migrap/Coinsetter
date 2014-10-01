
namespace Coinsetter {
    public class Side {
        private static readonly Side _buy = new Side("BUY");
        private static readonly Side _sell = new Side("SELL");

        private string _value;
        private Side(string value) {
            _value = value;
        }

        public static Side Buy {
            get { return _buy; }
        }

        public static Side Sell {
            get { return _sell; }
        }

        public override string ToString() {
            return _value;
        }
    }
}
