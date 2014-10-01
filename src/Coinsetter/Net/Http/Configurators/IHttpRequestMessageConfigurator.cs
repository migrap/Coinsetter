using System.Net.Http;

namespace Coinsetter.Net.Http.Configurators {
    internal interface IHttpRequestMessageConfigurator {
        IHttpRequestMessageConfigurator Method(HttpMethod value);
        IHttpRequestMessageConfigurator Content(HttpContent value);
        IHttpRequestMessageConfigurator Properties(string name, object value);
        IHttpRequestMessageConfigurator Address(string value);
        IHttpRequestMessageConfigurator Header(string name, string value);
    }
}
