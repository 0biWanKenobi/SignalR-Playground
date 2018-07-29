using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalR.WebApp
{
    public class ServerHub : Hub
    {
        public void Send(string name, string message, string group)
        {
            // Call the broadcastMessage method to update clients.
            var context = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
            context.Clients.Group(group).Send(name, message);
        }

        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }
    }
}