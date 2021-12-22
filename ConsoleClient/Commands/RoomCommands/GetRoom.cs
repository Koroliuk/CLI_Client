using ConsoleClient.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ConsoleClient.Commands.RoomCommands
{
    class GetRoom : Command
    {
        public GetRoom(HttpClient httpClient, string path) : base(httpClient, path)
        {
        }

        public override void Execute()
        {
            try
            {
                Console.Write("Enter a room number: ");
                int roomNumber = Convert.ToInt32(Console.ReadLine());
                var requestString = path + "/api/rooms/" + roomNumber;
                var result = httpClient.GetAsync(requestString).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var roomString = result.Content.ReadAsStringAsync().Result;
                    var room = JsonConvert.DeserializeObject<Room>(roomString);
                    Console.WriteLine($"\n{room.ToString()}\n");
                }
                else
                {
                    Console.WriteLine("There is no room with a such number");
                }
            } catch
            {
                Console.WriteLine("Invalid input data");
            }
        }
    }
}
