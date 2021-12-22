using ConsoleClient.Commands.OrderCommands;
using ConsoleClient.Commands.RoomCommands;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ConsoleClient.Commands
{
    class Launcher
    {
        private readonly HttpClient httpClient;
        private readonly string path;
        private Dictionary<string, Command> commands;

        public Launcher(HttpClient httpClient, string path)
        {
            this.httpClient = httpClient;
            this.path = path;
        }

        public void Start()
        {
            Init();
            while (true)
            {
                Console.Write("Enter a command (h for help): ");
                string command = Console.ReadLine();
                if (command == "exit")
                {
                    break;
                }
                try
                {
                    commands[command].Execute();
                } 
                catch
                {
                    Console.WriteLine("\nInvalid command\n");
                }
            }
        }

        private void Init()
        {
            commands = new Dictionary<string, Command>
            {
                { "room", new GetRoom(httpClient, path)},
                { "free rooms", new GetFreeRooms(httpClient, path)},
                { "orders", new GetOrders(httpClient, path)},
                { "cancel order", new DeleteOrder(httpClient, path)},
                { "pay order", new PayOrder(httpClient, path)},
                { "create order", new CreateOrder(httpClient, path)}
            };
        }
    }
}
