using Coinsetter.Configurators;
using Coinsetter.Models;
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Coinsetter {
    public partial class CoinsetterClient {

        public Task<OrderResponse> SendOrderAsync(Action<IAddOrderConfigurator> configure) {
            var content = Configure<IAddOrderConfigurator, AddOrderConfigurator>(configure).Build();

            return _client.SendAsync(x => x
                .Method(HttpMethod.Post)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/order")
                .Content(content, _formatter)
            ).ReadAsAsync<OrderResponse>(_formatter);
        }

        public Task<CancelResponse> CancelOrderAsync(Action<ICancelOrderConfigurator> configure) {
            var content = Configure<ICancelOrderConfigurator, CancelOrderConfigurator>(configure).Build();

            return _client.SendAsync(x => x
                .Method(HttpMethod.Delete)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/order/{0}", content.OrderUuid)
            ).ReadAsAsync<CancelResponse>(_formatter);
        }

        public Task<int> CancelOrdersAsync(string accountUuid = null, params Order[] orders) {
            var tcs = new TaskCompletionSource<int>();

            orders = (orders.Length != 0) ? (orders) : (orders = GetOrdersAsync(accountUuid: accountUuid, view: View.Open).Result.ToArray());

            foreach(var order in orders) {
                CancelOrderAsync(x => x.OrderUuid(order.OrderUuid));
            }
            tcs.SetResult(orders.Length);
            return tcs.Task;
        }

        //public Task<Orders> GetOrdersAsync(Action<IGetOrdersConfigurator> configure) {
        //    var settings = Configure<IGetOrdersConfigurator, GetOrdersConfigurator>(configure).Build();
        //    return GetOrdersAsync(settings.AccountUuid, settings.View);
        //}

        public Task<Orders> GetOrdersAsync(string accountUuid = null, View view = default(View)) {
            return _client.SendAsync(x => x
                .Method(HttpMethod.Get)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/customer/account/{0}/order{1}", accountUuid, (view.IsNullOrEmpty()) ? string.Empty : "?view={0}".FormatWith(view))
            ).ReadAsAsync<Orders>(_formatter);
        }

        public Task<Order> GetOrderAsync(string orderUuid = (string)null) {
            return _client.SendAsync(x => x
               .Method(HttpMethod.Get)
               .Header(CoinsetterClientSessionId, _session.Uuid)
               .Address("v1/order/{0}", orderUuid)
           ).ReadAsAsync<Order>(_formatter);
        }

        public IObservable<Order> GetOrdersObservable(string accountUuid, View view = default(View), TimeSpan interval = default(TimeSpan)) {
            return _client.Observe(interval, x => x
                .Method(HttpMethod.Get)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/customer/account/{0}/order{1}", accountUuid, (view.IsNullOrEmpty()) ? string.Empty : "?view={0}".FormatWith(view))
            ).Select(x => x.ReadAsAsync<Orders>(_formatter).Result).Except(x => x.CustomerUuid, x => x.AccountUuid, x => x.OrderUuid, x => x.OrderNumber, x => x.Symbol, x => x.Quantity, x => x.Stage, x => x.Filled, x => x.Open);
        }

        public IObservable<Order> GetOrderObservable(string accountUuid = (string)null, string orderUuid = (string)null, TimeSpan interval = default(TimeSpan)) {
            new { accountUuid, orderUuid }.CheckNotNull();
            return _client.Observe(interval, x => x
                .Method(HttpMethod.Get)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/order/{0}", orderUuid)
            ).Select(x => x.ReadAsAsync<Order>(_formatter).Result).Where(x => x.OrderUuid == orderUuid)
            .Do(o => Debug.WriteLine(o))
            .DistinctUntilChanged(x => x.CustomerUuid, x => x.AccountUuid, x => x.OrderUuid, x => x.Stage, x => x.Filled, x => x.Open);
        }

        public Task<string> GetTransactionsAsync(string accountUuid = (string)null, DateTime dateStart = default(DateTime), DateTime dateEnd = default(DateTime)) {
            Contract.Requires(null != accountUuid);
            var content = (object)null;

            if(dateStart != default(DateTime) && dateEnd == default(DateTime)) {
                content = new { accountUuid = accountUuid, dateStart = dateStart.ToString("ddMMyyyy") };
            } else if(dateStart == default(DateTime) && dateEnd != default(DateTime)) {
                content = new { accountUuid = accountUuid, dateEnd = dateEnd.ToString("ddMMyyyy") };
            } else {
                content = new { accountUuid = accountUuid };
            }

            return _client.SendAsync(x => x
                .Method(HttpMethod.Get)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/customer/account/{0}/financialTransaction", accountUuid)
                .Content(content, _formatter)
            ).ReadAsStringAsync();
        }

        public Task<string> GetTransactionAsync(string financialTransactionUuid = (string)null) {
            Contract.Requires(null != financialTransactionUuid);

            return _client.SendAsync(x => x
                .Method(HttpMethod.Get)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/financialTransaction/{financialTransactionUuid}", financialTransactionUuid)
            ).ReadAsStringAsync();
        }

        public Task<Positions> GetPositionsAsync(string accountUuid = (string)null) {
            Contract.Requires(null != accountUuid);
            return _client.SendAsync(x => x
                .Method(HttpMethod.Get)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/customer/account/{0}/position", accountUuid)
            ).ReadAsAsync<Positions>(_formatter);
        }

        public IObservable<Position> GetPositionsObservable(string accountUuid = (string)null, TimeSpan interval = default(TimeSpan)) {
            return _client.Observe(interval, x => x
                .Method(HttpMethod.Get)
                .Header(CoinsetterClientSessionId, _session.Uuid)
                .Address("v1/customer/account/{0}/position", accountUuid)
            ).Select(x => x.ReadAsAsync<Positions>(_formatter).Result).Except(x => x.CustomerUuid, x => x.AccountUuid, x => x.Symbol, x => x.Quantity, x => x.Vwap, x => x.Side);
        }
    }
}