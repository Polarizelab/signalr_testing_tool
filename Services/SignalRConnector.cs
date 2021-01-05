using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using signalr_test_tools.Models;

namespace signalr_test_tools.Services
{
    public class SignalRConnector
    {
        private IList<string> _listeners;
        public HubConnection Hub;
        public event Action<string, object> OnReceive;
        public SignalRConnector()
        {
            _listeners = new List<string>();
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
        public void Listen(string methodName)
        {
            if (_listeners.Any(f => f.Equals(methodName, StringComparison.CurrentCultureIgnoreCase)))
                return;
            _listeners.Add(methodName);
            Hub.On<object>(methodName, (arg) => OnReceive.Invoke(methodName, arg));
        }
    }
}