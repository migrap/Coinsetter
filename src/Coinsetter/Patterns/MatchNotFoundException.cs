using System;

namespace Coinsetter.Patterns {
    public class MatchNotFoundException : Exception {
        public MatchNotFoundException(string message)
            : base(message) {
        }
    }
}
