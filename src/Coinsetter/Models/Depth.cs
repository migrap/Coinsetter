using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinsetter.Models {
    public class Depth : List<BidAsk>{
        public Depth() {
        }

        public Depth(IEnumerable<BidAsk> collection)
            : base(collection) {
        }
    }    
}
