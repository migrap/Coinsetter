
namespace Coinsetter.Patterns {
    public static partial class Extensions {

        public static PatternMatchContext<T> Match<T>(this T value) {
            return new PatternMatchContext<T>(value);
        }

        public static PatternMatchContext<T, TResult> MatchWithResult<TResult, T>(this T value) {
            return new PatternMatchContext<T, TResult>(value);
        }
    }
}