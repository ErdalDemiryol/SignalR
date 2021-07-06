using Microsoft.AspNetCore.SignalR;
using Notifications.Hubs;
using System.Threading.Tasks;

namespace Notifications.Business
{
    public class MyBusiness
    {
        readonly IHubContext<MyHub> _hubContext;
        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            //Extra işlemler buraya yazılabilir..
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }



    }
}
