using Coinsetter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Coinsetter {
    public partial class CoinsetterClient {
        public Task<Last> GetLastAsync() {
            return _client.SendAsync(x => x
                .Method(HttpMethod.Get)
                .Address("v1/marketdata/last")
            ).ReadAsAsync<Last>(_formatter);
        }

        public Task<Ticker> GetTickerAsync() {
            return _client.SendAsync(x => x
                .Method(HttpMethod.Get)
                .Address("v1/marketdata/ticker")
            ).ReadAsAsync<Ticker>(_formatter);
        }

        //public Task<OrderBook> GetDepthAsync() {
        //    return _client.SendAsync(x => x
        //        .Method(HttpMethod.Get)
        //        .Address("v1/marketdata/depth")
        //    ).ReadAsAsync<OrderBook>(_formatter);
        //}

        public Task<Quote> GetQuoteAsync(string symbol = null, double? quantity = null) {
            return _client.SendAsync(x => x
                .Method(HttpMethod.Get)
                .Address("v1/marketdata/quote", new { symbol = symbol, quantity = quantity })
            ).ReadAsAsync<Quote>(_formatter);
        }
    }
}
