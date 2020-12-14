using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using signalr_test_tools.Models;

namespace signalr_test_tools.Services
{
    public class SignalRConnector
    {
        public HubConnection Hub;
        public SignalRConnector()
        {
        }
        public async Task<string> Connect(string url)
        {
            try
            {
                var hubBuilder = new HubConnectionBuilder();
                Hub = hubBuilder.WithUrl(url).Build();
                await Hub.StartAsync();
                return string.Empty;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public async Task<string> Invoke(Message param)
        {
            try
            {
                object data = param.DataText;
                if (param.Data != null) data = param.Data;
                await Hub.InvokeAsync(param.MethodName, data);
                return string.Empty;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}