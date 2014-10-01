
namespace Coinsetter.Configurators {
    public interface ILoginConfigurator {
        ILoginConfigurator Username(string value);
        ILoginConfigurator Password(string value);
    }
}
