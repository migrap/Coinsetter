//using Coinsetter.Models;
//using Newtonsoft.Json;
//using SocketIOClient;
//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Reactive.Linq;
//using System.Reactive.Subjects;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Coinsetter {
//    public partial class CoinsetterClient {
//        private ISubject<object> _observable = new Subject<object>();
//        private Client _socketio;
//        private ConcurrentDictionary<Type, object> _messages = new ConcurrentDictionary<Type, object>();
//        private bool _connected = false;
//        private object _connectionLock = new object();
//        private object _connectionTarget;

//        private Task<bool> ConnectAsync(string address = "https://plug.coinsetter.com:3000/socket.io/socket.io.js") {
//            var tcs = new TaskCompletionSource<bool>();
//            _socketio = new Client(address);

//            _socketio.On("ticker", (fn) => {
//                var msg = JsonConvert.DeserializeAnonymousType(fn.MessageText, new { name = default(string), args = default(List<Ticker>) });
//                foreach(var item in msg.args) {
//                    _observable.OnNext(item);
//                }
//            });

//            _socketio.On("last", (fn) => {
//                var msg = JsonConvert.DeserializeAnonymousType(fn.MessageText, new { name = default(string), args = default(List<Last>) });
//                foreach(var item in msg.args) {
//                    _observable.OnNext(item);
//                }
//            });

//            _socketio.On("levels", (fn) => {
//                Console.Write(fn.MessageText);
//            });

//            _socketio.On("depth", (fn) => {
//                var msg = JsonConvert.DeserializeAnonymousType(fn.MessageText, new { name = default(string), args = default(List<Depth>) });
//                foreach(var item in msg.args) {
//                    _observable.OnNext(item);
//                }
//            });

//            var opened = (EventHandler)null;
//            var closed = (EventHandler)null;
//            var error = (EventHandler<ErrorEventArgs>)null;

//            _socketio.Message += (s, m) => {
//                Console.WriteLine(m.Message.Event);
//            };

//            _socketio.Opened += opened = (s, e) => {
//                _socketio.Opened -= opened;
//                tcs.SetResult(true);
//            };

//            _socketio.SocketConnectionClosed += closed = (s, e) => {
//                _socketio.SocketConnectionClosed -= closed;
//                _socketio.Dispose();
//                _socketio = null;
//                tcs.SetResult(false);
//            };

//            _socketio.Error += error = (s, e) => {
//                Debug.WriteLine("{0} {1}", e.Message, e.Exception);
//            };

//            _socketio.Connect();

//            return tcs.Task;
//        }

//        private IObservable<T> GetObservable<T>(string eventname) {
//            LazyInitializer.EnsureInitialized(ref _connectionTarget, ref _connected, ref _connectionLock, () => {
//                _connected = ConnectAsync().Result;
//                return null;
//            });

//            return (IObservable<T>)_messages.GetOrAdd(typeof(T), (type) => {
//                if(_socketio.IsConnected) {
//                    _socketio.Emit(eventname, null);
//                }
//                return _observable.OfType<T>();
//            });
//        }

//        public IObservable<Ticker> GetTickerObservable() {
//            return (IObservable<Ticker>)GetObservable<Ticker>("ticker room");
//        }

//        public IObservable<Last> GetLastObservable() {
//            return (IObservable<Last>)GetObservable<Last>("last room");
//        }

//        public IObservable<Depth> GetDepthObservable() {
//            return (IObservable<Depth>)GetObservable<Depth>("depth room");
//        }

//        public IObservable<Orders> GetOrdersObservable(string customerUuid) {
//            new { customerUuid }.CheckNotNull();
//            return (IObservable<Orders>)GetObservable<Orders>("order-{0} room".FormatWith(customerUuid));
//        }

//        public IObservable<Levels> GetLevelsObservable() {
//            return (IObservable<Levels>)GetObservable<Levels>("levels room");
//        }
//    }
//}