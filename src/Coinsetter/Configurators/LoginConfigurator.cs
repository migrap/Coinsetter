
namespace Coinsetter.Configurators {
    internal class LoginConfigurator : ILoginConfigurator {
        private LoginSettings _settings = new LoginSettings();

        public ILoginConfigurator Username(string value) {
            _settings.Username = value;
            return this;
        }

        public ILoginConfigurator Password(string value) {
            _settings.Password = value;
            return this;
        }

        public LoginSettings Build() {
            return _settings;
        }
    }
}
