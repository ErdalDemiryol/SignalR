using SignalRChatServer.Models;
using System.Collections.Generic;

namespace SignalRChatServer.Data
{
    public static class ClientSource
    {
        public static List<Client> Clients { get; } = new List<Client>();
    }
}
