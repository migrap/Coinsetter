using System.Collections.Generic;

namespace Coinsetter.Models {
    public class Positions : List<Position> {
        public Positions() {
        }

        public Positions(IEnumerable<Position> collection)
            : base(collection) {
        }
    }
}