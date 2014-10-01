using Coinsetter.Collections.Generic;
using Coinsetter.Models;
using Coinsetter.Net.Http.Configurators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coinsetter {
    public static partial class Extensions {
        internal static Task<T> ReadAsAsync<T>(this Task<HttpResponseMessage> message, params MediaTypeFormatter[] formatters) {
            var response = message
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<T>(formatters);
        }

        internal static Task<string> ReadAsStringAsync(this Task<HttpResponseMessage> message) {
            var response = message
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync();
        }

        internal static Task<T> ReadAsAsync<T>(this HttpResponseMessage message, MediaTypeFormatter formatter) {
            return ReadAsAsync<T>(message.Content, formatter);
        }

        internal static Task<T> ReadAsAsync<T>(this HttpContent content, MediaTypeFormatter formatter) {
            return content.ReadAsAsync<T>(new[] { formatter });
        }

        internal static void ContinueOrCancel(this CancellationTokenSource self) {
            self.Token.ContinueOrCancel();
        }

        internal static void ContinueOrCancel(this CancellationToken self) {
            if(self.IsCancellationRequested) {
                self.ThrowIfCancellationRequested();
            }
        }

        internal static string FormatWith(this string format, params object[] args) {
            return string.Format(format, args);
        }

        private static TResult Configure<TSource, TResult>(Action<TSource> configure) where TResult : TSource, new() {
            var result = new TResult();
            configure(result);
            return result;
        }

        internal static Task<HttpResponseMessage> SendAsync(this HttpClient client, Action<IHttpRequestMessageConfigurator> configure) {
            var request = Configure<IHttpRequestMessageConfigurator, HttpRequestMessageConfigurator>(configure).Build();
            return client.SendAsync(request);
        }

        internal static IHttpRequestMessageConfigurator Address(this IHttpRequestMessageConfigurator self, string address, object args) {
            var properties = args.ToDictionary();
            if(properties.Any()) {
                address = "{0}?{1}".FormatWith(address, string.Join("&", properties.Select(x => "{0}={1}".FormatWith(x.Key, x.Value))));
            }
            return self.Address(address);
        }

        internal static IHttpRequestMessageConfigurator Address(this IHttpRequestMessageConfigurator self, string format, params object[] args) {
            return self.Address(format.FormatWith(args));
        }

        internal static IHttpRequestMessageConfigurator Content(this IHttpRequestMessageConfigurator self, object value, MediaTypeFormatter formatter) {
            return self.Content(new ObjectContent(value.GetType(), value, formatter));
        }

        internal static bool IsNullOrEmpty(this View self) {
            return (null == self) || (self.ToString().IsNullOrEmpty());
        }

        internal static bool IsNullOrEmpty(this string self) {
            return string.IsNullOrEmpty(self);
        }

        internal static Task<T> ContinueWith<T>(this Task<T> self, Action<T> callback = null) {
            var tcs = new TaskCompletionSource<T>();
            self.ContinueWith(x => {
                var result = x.Result;
                if(null != callback) {
                    callback(result);
                }
                tcs.SetResult(result);
            });
            return tcs.Task;
        }

        public static bool EnsureSuccessStatus(this OrderResponse self) {
            return "SUCCESS".Equals(self.Status, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool EnsureSuccessStatus(this CancelResponse self) {
            return "SUCCESS".Equals(self.Status, StringComparison.InvariantCultureIgnoreCase);
        }

        public static IObservable<T> Except<T>(this IObservable<IEnumerable<T>> source, params Expression<Func<T, object>>[] expressions) where T : class {
            return Observable.Create<T>(observer => {
                var disposed = false;
                var gate = new AsyncLock();
                var cancel = new CancellationTokenSource();
                var collection = (List<T>)null;
                var comparer = new PropertiesEqualityComparer<T>(expressions);
                var create = new Func<IEnumerable<T>, Action<T>, List<T>>((c, a) => {
                    var list = new List<T>(c);
                    return list;
                });

                Action<T> next = observer.OnNext;

                source.Subscribe(x => {
                    collection = collection ?? (collection = create(x, next));

                    foreach(var item in x.Except(collection, comparer)) {
                        var index = collection.FindIndex(item, comparer);
                        if(index == -1) {
                            collection.Add(item);
                        } else {
                            collection[index] = item;
                        }
                        next(item);
                    }
                });

                return new CompositeDisposable(Disposable.Create(() => gate.Wait(() => {
                    cancel.Cancel();
                })), Disposable.Create(() => gate.Wait(() => {
                    disposed = true;
                })));
            });
        }

        internal static int FindIndex<T>(this IList<T> source, T item, params Expression<Func<T, object>>[] expressions) {
            var comparer = new PropertiesEqualityComparer<T>(expressions);
            return source.FindIndex(item, comparer);
        }

        internal static int FindIndex<T>(this IList<T> source, T item, PropertiesEqualityComparer<T> comparer) {
            for(int i = 0; i < source.Count; i++) {
                if(comparer.Equals(source[i], item)) {
                    return i;
                }
            }
            return -1;
        }

        internal static IObservable<T> DistinctUntilChanged<T>(this IObservable<T> source, params Expression<Func<T, object>>[] expressions) {
            return source.DistinctUntilChanged(new PropertiesEqualityComparer<T>(expressions));
        }

        internal static IEnumerable<T> Except<T>(this IEnumerable<T> source, IEnumerable<T> collection, params Expression<Func<T, object>>[] expressions) {
            return source.Except(collection, new PropertiesEqualityComparer<T>(expressions));
        }

        public static Task<Positions> GetPositionsAsync(this CoinsetterClient client, Account account = (Account)null) {
            Contract.Requires(null != account);
            return client.GetPositionsAsync(accountUuid: account.AccountUuid);
        }

        internal static IObservable<HttpResponseMessage> Observe(this HttpClient client, TimeSpan interval, Action<IHttpRequestMessageConfigurator> configure) {
            return Observe(client, interval, null, configure);
        }

        internal static IObservable<HttpResponseMessage> Observe(this HttpClient client, TimeSpan interval, IScheduler scheduler, Action<IHttpRequestMessageConfigurator> configure) {
            return Observable.Timer(interval, scheduler ?? TaskPoolScheduler.Default).Repeat().Select(x => {
                var request = Configure<IHttpRequestMessageConfigurator, HttpRequestMessageConfigurator>(configure).Build();

                var response = client.SendAsync(request)
                    .GetAwaiter()
                    .GetResult()
                    .EnsureSuccessStatusCode();

                return response;
            });
        }

        internal static IDictionary<string,string> ToDictionary(this object self) {
            var dictionary = new Dictionary<string, string>();
            foreach(PropertyDescriptor property in TypeDescriptor.GetProperties(self)) {
                var value = property.GetValue(self);
                if(null != value) {
                    dictionary.Add(property.Name, value.ToString());
                }
            }
            return dictionary;
        }

        public static void CheckNotNull<T>(this T value) where T : class {
            if(null == value) {
                throw new ArgumentNullException("value");
            }
            NullChecker<T>.Check(value);
        }

        private static class NullChecker<T> where T : class {
            private static readonly List<Func<T, bool>> _checkers = new List<Func<T, bool>>();
            private static readonly List<string> _names = new List<string>();

            static NullChecker() {
                foreach(var name in typeof(T).GetConstructors()[0].GetParameters().Select(p => p.Name)) {
                    _names.Add(name);
                    var property = typeof(T).GetProperty(name);

                    if(property.PropertyType.IsValueType) {
                        throw new ArgumentException("Property " + property + " is a value type");
                    }

                    var parameter = Expression.Parameter(typeof(T), "value");
                    var accessor = Expression.Property(parameter, property);
                    var nullvalue = Expression.Constant(null, property.PropertyType);
                    var equality = Expression.Equal(accessor, nullvalue);
                    var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);
                    _checkers.Add(lambda.Compile());
                }
            }

            internal static void Check(T value) {
                for(int i = 0; i < _checkers.Count; i++) {
                    if(_checkers[i](value)) {
                        throw new ArgumentNullException(_names[i]);
                    }
                }
            }
        }
    }
}