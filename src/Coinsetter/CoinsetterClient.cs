using Coinsetter.Configurators;
using Coinsetter.Models;
using Coinsetter.Net.Http;
using Coinsetter.Net.Http.Formatting;
using System;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Coinsetter {
    public partial class CoinsetterClient {
        private readonly string CoinsetterClientSessionId = "coinsetter-client-session-id";

        private HttpClient _client = new HttpClient(new CoinsetterDelegatingHandler()) {
            BaseAddress = new Uri("https://api.coinsetter.com")
        };
        private MediaTypeFormatter _formatter = new CoinsetterMediaTypeFormatter();

        static CoinsetterClient() {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, error) => true;
            ServicePointManager.FindServicePoint(new Uri("https://api.coinsetter.com")).ConnectionLimit = 8;
        }

        private Session _session;

        public CoinsetterClient() {
        }

        private static TResult Configure<TSource, TResult>(Action<TSource> configure) where TResult : TSource, new() {
            var result = new TResult();
            configure(result);
            return result;
        }

        public Task<Session> LoginAsync(string username = (string)null, string password = (string)null, string address = "0.0.0.0") {
            Contract.Requires(null != username);
            Contract.Requires(null != password);

            return LoginAsync(x => x
                .Username(username)
                .Password(password)
            );
        }

        public Task<Session> LoginAsync(Action<ILoginConfigurator> configure) {
            var settings = Configure<ILoginConfigurator, LoginConfigurator>(configure).Build();

            return _client.SendAsync(x => x
                .Method(HttpMethod.Post)
                .Address("v1/clientSession")
                .Content(new { username = settings.Username, ipAddress = "0.0.0.0", password = settings.Password }, _formatter)
            ).ReadAsAsync<Session>(_formatter).ContinueWith(x => _session = x);
        }

        public Task<Logout> LogoutAsync() {
            return _client.SendAsync(x => x
                .Method(HttpMethod.Put)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/clientSession/{clientSessionId}?action=LOGOUT", _session.Uuid)
            ).ReadAsAsync<Logout>(_formatter);
        }

        public Task<Heartbeat> HeartbeatAsync() {
            return _client.SendAsync(x => x
                .Method(HttpMethod.Put)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/clientSession/{0}?action=HEARTBEAT", _session.Uuid)
            ).ReadAsAsync<Heartbeat>(_formatter);
        }        

        public Task<Accounts> GetAccountsAsync() {
            return _client.SendAsync(x => x
                .Method(HttpMethod.Get)
                .Address("v1/customer/account")
                .Header(CoinsetterClientSessionId, _session.Uuid)
            ).ReadAsAsync<Accounts>(_formatter);
        }
    }
}

/*
 * When marking a call to Order:Add I can optionally pass a clientOrderId. When I Order:Get, clientOrderId isn't passed back
 * Documentation on Order:List is wrong:
 *  Parameters: WORKING         Response: PENDING
 *  Parameters: PARTIAL_FIL     Response: PARTIAL_FILL
 *  Parameters: FILLED          Response:
*/