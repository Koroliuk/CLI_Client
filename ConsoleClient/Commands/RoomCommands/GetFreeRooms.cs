using ConsoleClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;

namespace ConsoleClient.Commands.RoomCommands
{
    class GetFreeRooms : Command
    {
        public GetFreeRooms(HttpClient httpClient, string path) : base(httpClient, path)
        {
        }

        public override void Execute()
        {
            Console.Write("Enter a start date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.Write("Enter an end date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var requestString = path + "/api/rooms"+$"?start={startDate}&end={endDate}";
            var result = httpClient.GetAsync(requestString).Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var roomListString = result.Content.ReadAsStringAsync().Result;
                var roomList = JsonConvert.DeserializeObject<List<Room>>(roomListString);

                foreach (var room in roomList)
                {
                    Console.WriteLine($"\n{room.ToString()}");
                }
                Console.WriteLine();
            }
            else
            {
                var messageString = result.Content.ReadAsStringAsync().Result;
                var messageResult = JsonConvert.DeserializeObject<RequestMessageResult>(messageString);
                Console.WriteLine($"\n{messageResult.Message}\n");
            }
        }
    }
}
