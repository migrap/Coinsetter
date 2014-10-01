using System;
using System.Linq;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Reactive.Subjects;
using System.Reactive.Concurrency;
using Newtonsoft.Json;
using System.IO;
using Coinsetter;

namespace Sandbox {
    class Program {
        static void Main(string[] args) {
            var coinsetter = new CoinsetterClient();
            coinsetter.GetQuoteAsync(symbol: "BTCUSD");
        }
    }
}