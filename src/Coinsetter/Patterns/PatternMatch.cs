using System;
using System.Collections.Generic;

namespace Coinsetter.Patterns {
    public class PatternMatch<T> {
        private readonly T _value;
        private readonly List<Tuple<Predicate<T>, Action<T>>> _cases = new List<Tuple<Predicate<T>, Action<T>>>();
        private Action<T> _else;

        internal PatternMatch(T value) {
            _value = value;
        }

        public PatternMatch<T> With(Predicate<T> condition, Action<T> action) {
            _cases.Add(new Tuple<Predicate<T>, Action<T>>(condition, action));
            return this;
        }

        public PatternMatch<T> With(T value, Action<T> action) {
            _cases.Add(new Tuple<Predicate<T>, Action<T>>(new Predicate<T>((v) => { return v.Equals(value); }), action));
            return this;
        }

        public PatternMatch<T> Else(Action<T> action) {
            if(null != _else) {
                throw new InvalidOperationException("Cannoit have multiple else cases");
            }
            _else = action;
            return this;
        }

        public void Do() {
            if(null != _else) {
                _cases.Add(new Tuple<Predicate<T>, Action<T>>(x => true, _else));
            }

            foreach(var c in _cases) {
                if(c.Item1(_value)) {
                    c.Item2(_value);
                    return;
                }
            }

            throw new MatchNotFoundException("Incomplete pattern match");
        }
    }

    public class PatternMatch<T, TResult> {
        private readonly T _value;
        private readonly List<Tuple<Predicate<T>, Func<T, TResult>>> _cases = new List<Tuple<Predicate<T>, Func<T, TResult>>>();
        private Func<T, TResult> _elseFunc;

        internal PatternMatch(T value) {
            _value = value;
        }

        public PatternMatch<T, TResult> With(Predicate<T> condition, Func<T, TResult> result) {
            _cases.Add(new Tuple<Predicate<T>, Func<T, TResult>>(condition, result));
            return this;
        }

        public PatternMatch<T, TResult> With(Predicate<T> condition, TResult result) {
            _cases.Add(new Tuple<Predicate<T>, Func<T, TResult>>(condition, (t) => result));
            return this;
        }

        public PatternMatch<T, TResult> With(T value, TResult result) {
            _cases.Add(new Tuple<Predicate<T>, Func<T, TResult>>(new Predicate<T>((v) => { return v.Equals(value); }), new Func<T, TResult>((t) => { return result; })));
            return this;
        }

        public PatternMatch<T, TResult> With(T value, Func<T, TResult> result) {
            _cases.Add(new Tuple<Predicate<T>, Func<T, TResult>>(new Predicate<T>((v) => { return v.Equals(value); }), result));
            return this;
        }

        public PatternMatch<T, TResult> Else(Func<T, TResult> result) {
            if(null != _elseFunc) {
                throw new InvalidOperationException("Cannot have multiple else cases");
            }
            _elseFunc = result;
            return this;
        }

        public TResult Do() {
            if(null != _elseFunc) {
                _cases.Add(new Tuple<Predicate<T>, Func<T, TResult>>(x => true, _elseFunc));
            }

            foreach(var item in _cases) {
                if(item.Item1(_value)) {
                    return item.Item2(_value);
                }
            }

            throw new MatchNotFoundException("Incomplete pattern match");
        }
    }
}
