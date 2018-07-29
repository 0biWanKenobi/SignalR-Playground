using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalR.ClientApp2
{
    class Program
    {
        public static async Task Main()
        {
            var hubConnection = new HubConnection("http://localhost:50682/");
            var serverProxy = hubConnection.CreateHubProxy("ServerHub");


            serverProxy.On<string, string>("Send", (sender, message) =>
                Console.WriteLine($"Message from {sender}: {message}")
            );

            await hubConnection.Start().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine($"There was an error opening the connection:{task.Exception?.GetBaseException()}");
                }
                else
                {
                    Console.WriteLine("Connected");
                    serverProxy.Invoke("JoinGroup", "consoleGroup2").ContinueWith(taskJoin =>
                    {
                        Console.WriteLine(task.IsFaulted ? $"There was an error joining the group:{task.Exception?.GetBaseException()}" : "Group Joined");
                    });
                }

            });


            Console.ReadLine();
        }
    }
}
