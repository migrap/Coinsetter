using System.Collections.Generic;

namespace Coinsetter.Models {
    public class Transactions : List<Transaction> {
        public Transactions() {
        }

        public Transactions(IEnumerable<Transaction> collection)
            : base(collection) {
        }
    }
}