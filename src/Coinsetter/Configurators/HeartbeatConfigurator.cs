using Coinsetter.Models;

namespace Coinsetter.Configurators {
    internal class HeartbeatConfigurator : IHeartbeatConfigurator {
        private HeartbeatSettings _settings = new HeartbeatSettings();

        public IHeartbeatConfigurator Session(Session value) {
            _settings.Session = value;
            return this;
        }

        public HeartbeatSettings Build() {
            return _settings;
        }
    }
}
