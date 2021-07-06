using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifications.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //{
        public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        {

            #region Caller

            // Sadece server a bildirim gönderen client'la ilitişim kurar.
            //await Clients.Caller.SendAsync("receiveMessage", message);

            #endregion

            #region All

            // Server'a bağlı olan tüm client'larla ilitişim kurar.
            //await Clients.All.SendAsync("receiveMessage", message);

            #endregion

            #region Other
            // Sadece Server'a bildirim gönderen client dışında Server'a bağlı olan tüm Client'lara mesaj gönderir.
            //await Clients.Others.SendAsync("receiveMessage", message);

            #endregion


            #region Hub Clients Metotları

            #region AllExcept

            //Belirtilen clientlar hariç server'a bağlı olan tüm clientlara bildiride bulunabilir..
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);

            #endregion

            #region Client

            //Server'a bağlı olan clientlar arasından sadece belirli bir clienta bildiride bulunur.
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);

            #endregion

            #region Clients

            //Server'a bağlı olan clientlar arasından sadece belirtilenlere bildiride bulunur.
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);

            #endregion

            #region Group

            //Belirtilen gruptaki tüm clientlara bildiride bulunur.
            //Önce gruplar oluşturulmalı ve ardından clienlar gruplara subsc.olmalı.
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);

            #endregion

            #region GroupExcept
            //Belirtilen gruptaki, belirtilen clientlar dışındaki tüm clientlara mesaj iletmemizi sağlayan bir fonksiyondur.
            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Others In Groups
            //Bildiride bulunan client haricinde gruptaki tüm clientlara bildiride bulunan fonksiyondur.
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion

            #region User

            #endregion

            #region Users

            #endregion

            #endregion

        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }

    }
}
