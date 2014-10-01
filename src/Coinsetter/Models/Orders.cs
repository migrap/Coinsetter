using System.Collections.Generic;

namespace Coinsetter.Models {
    public class Orders : List<Order> {
        public Orders() {
        }

        public Orders(IEnumerable<Order> collection)
            : base(collection) {
        }
    }
}