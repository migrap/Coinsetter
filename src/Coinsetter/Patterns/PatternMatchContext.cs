using System;

namespace Coinsetter.Patterns {
    public class PatternMatchContext<T> {
        private readonly T _value;

        internal PatternMatchContext(T value) {
            _value = value;
        }

        public PatternMatch<T> With(Predicate<T> condition, Action<T> action) {
            var match = new PatternMatch<T>(_value);
            return match.With(condition, action);
        }

        public PatternMatch<T> With(T value, Action<T> action) {
            var match = new PatternMatch<T>(_value);
            return match.With(new Predicate<T>((v) => { return v.Equals(value); }), action);
        }

        public PatternMatch<T, TResult> With<TResult>(Predicate<T> condition, Func<T, TResult> result) {
            var match = new PatternMatch<T, TResult>(_value);
            return match.With(condition, result);
        }

        public PatternMatch<T, TResult> With<TResult>(T value, Func<T, TResult> result) {
            var match = new PatternMatch<T, TResult>(_value);
            return match.With(new Predicate<T>((v) => { return v.Equals(value); }), result);
        }

        public PatternMatch<T, TResult> With<TResult>(Predicate<T> condition, TResult result) {
            var match = new PatternMatch<T, TResult>(_value);
            return match.With(condition, new Func<T, TResult>((t) => { return result; }));
        }

        public PatternMatch<T, TResult> With<TResult>(T value, TResult result) {
            var match = new PatternMatch<T, TResult>(_value);
            return match.With(new Predicate<T>((v) => { return v.Equals(value); }), new Func<T, TResult>((t) => { return result; }));
        }
    }

    public class PatternMatchContext<T, TResult> {
        private readonly T _value;

        internal PatternMatchContext(T value) {
            _value = value;
        }

        public PatternMatch<T, TResult> With(Predicate<T> condition, Func<T, TResult> result) {
            var match = new PatternMatch<T, TResult>(_value);
            return match.With(condition, result);
        }

        public PatternMatch<T, TResult> With(T value, Func<T, TResult> result) {
            var match = new PatternMatch<T, TResult>(_value);
            return match.With(new Predicate<T>((v) => { return v.Equals(value); }), result);
        }

        public PatternMatch<T, TResult> With(Predicate<T> condition, TResult result) {
            var match = new PatternMatch<T, TResult>(_value);
            return match.With(condition, new Func<T, TResult>((t) => { return result; }));
        }

        public PatternMatch<T, TResult> With(T value, TResult result) {
            var match = new PatternMatch<T, TResult>(_value);
            return match.With(new Predicate<T>((v) => { return v.Equals(value); }), new Func<T, TResult>((t) => { return result; }));
        }
    }
}
