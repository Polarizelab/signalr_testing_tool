using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace signalr_test_tools.Services
{
    public class SignalRConnector
    {
        private HubConnection _hub;
        public SignalRConnector()
        {
        }
        public async Task<string> Connect(string url)
        {
            try
            {
                var  hubBuilder = new HubConnectionBuilder();
                _hub = hubBuilder.WithUrl(url).Build();
                await _hub.StartAsync();
                return string.Empty;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public Task Invoke(string methodName, string param)
        {
            return Task.CompletedTask;
        }
    }
}