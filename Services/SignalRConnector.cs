using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace signalr_test_tools.Services
{
    public class SignalRConnector
    {
        private HubConnection _hub;
        private HubConnectionBuilder _hubBuilder;
        public SignalRConnector()
        {
            _hubBuilder = new HubConnectionBuilder();
        }
        public Task Connect(string url)
        {
            _hub =  _hubBuilder.WithUrl(url).Build();
           return _hub.StartAsync();
        }
        public Task Invoke(string methodName, string param){
            return Task.CompletedTask;
        }
    }
}