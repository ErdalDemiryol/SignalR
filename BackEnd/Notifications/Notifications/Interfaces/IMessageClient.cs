using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifications.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task ReceiveMessage(string message);
        Task UserJoined(string connectionId);
        Task UserLeaved(string connectionId);
    }
}
