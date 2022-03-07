using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ZooLine.Hubs
{
    public class ChatHub : Hub
    {

        public async Task EnviarMensaje(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
    }
}
