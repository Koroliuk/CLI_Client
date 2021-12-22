using ConsoleClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace ConsoleClient.Commands.OrderCommands
{
    public class GetOrders : Command
    {
        public GetOrders(HttpClient httpClient, string path) : base(httpClient, path)
        {
        }

        public override void Execute()
        {
            var requestString = path + "/api/orders";
            var result = httpClient.GetAsync(requestString).Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var orderListString = result.Content.ReadAsStringAsync().Result;
                var orderList = JsonConvert.DeserializeObject<List<Order>>(orderListString);

                foreach (var order in orderList)
                {
                    Console.WriteLine($"\n{order.ToString()}");
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
