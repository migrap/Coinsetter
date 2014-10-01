
namespace Coinsetter {
    public class View {
        private static readonly View _new = new View("NEW");
        private static readonly View _working = new View("WORKING");
        private static readonly View _partial = new View("PARTIAL_FILL");
        private static readonly View _filled = new View("FILLED");        
        private static readonly View _expired = new View("EXPIRED");
        private static readonly View _cancelled = new View("CANCELLED");
        private static readonly View _rejected = new View("REJECTED");
        private static readonly View _closed = new View("CLOSED");
        private static readonly View _open = new View("OPEN");
        private static readonly View _newfill = new View("NEW_FILL");
        private static readonly View _fill = new View("FILL");

        private readonly string _value;

        private View(string value) {
            _value = value;
        }

        public override string ToString() {
            return _value.ToString();
        }

        public static View New { get { return _new; } }

        public static View Working { get { return _working; } }
        
        public static View Partial { get { return _partial; } }

        public static View Filled { get { return _filled; } }

        public static View Expired { get { return _expired; } }

        public static View Cancelled { get { return _cancelled; } }

        public static View Rejected { get { return _rejected; } }

        public static View Closed { get { return _closed; } }

        public static View Open { get { return _open; } }

        public static View NewFill { get { return _newfill; } }

        public static View Fill { get { return _fill; } }
    }
}
