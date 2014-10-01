using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinsetter.Models {
    public class Levels : List<Level> {
        public Levels() {
        }

        public Levels(IEnumerable<Level> collection)
            : base(collection) {
        }
    }
}