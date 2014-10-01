
namespace Coinsetter {
    public class Stage {
        private static readonly Stage _new = new Stage("NEW");
        private static readonly Stage _pending = new Stage("PENDING");
        private static readonly Stage _open = new Stage("OPEN");
        private static readonly Stage _partial = new Stage("PARTIAL");
        private static readonly Stage _expired = new Stage("EXPIRED");
        private static readonly Stage _canceled = new Stage("CANCELED");
        private static readonly Stage _rejected = new Stage("REJECTED");
        private static readonly Stage _closed = new Stage("CLOSED");
        private static readonly Stage _routed = new Stage("ROUTED");
        private static readonly Stage _working = new Stage("WORKING");
        private static readonly Stage _filled = new Stage("FILLED");

        private readonly string _value;

        private Stage(string value) {
            _value = value;
        }

        public override string ToString() {
            return _value;
        }

        public static Stage New { get { return _new; } }

        public static Stage Pending { get { return _pending; } }

        public static Stage Open { get { return _open; } }

        public static Stage Partial { get { return _partial; } }

        public static Stage Expired { get { return _expired; } }

        public static Stage Canceled { get { return _canceled; } }

        public static Stage Rejected { get { return _rejected; } }

        public static Stage Closed { get { return _closed; } }

        public static Stage Routed { get { return _routed; } }

        public static Stage Working { get { return _working; } }

        public static Stage Filled { get { return _filled; } }
    }
}
