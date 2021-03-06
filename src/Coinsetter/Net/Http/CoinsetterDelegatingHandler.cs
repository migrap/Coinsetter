﻿using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Coinsetter.Net.Http {
    internal class CoinsetterDelegatingHandler : DelegatingHandler {
        public CoinsetterDelegatingHandler() {
            InnerHandler = new HttpClientHandler() {
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None,
            };
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            return base.SendAsync(request, cancellationToken);
        }
    }
}
