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
        public async Task<Exception> Connect(string url)
        {
            try
            {
                var hubBuilder = new HubConnectionBuilder();
                Hub = hubBuilder.WithUrl(url).Build();
                await Hub.StartAsync();
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }


        public async Task<Exception> Invoke(Message param)
        {
            try
            {
                object data = param.DataText;
                if (param.Data != null) data = param.Data;
                await Hub.InvokeAsync(param.MethodName, data);
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}