using ConsoleClient.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ConsoleClient.Commands.OrderCommands
{
    public class PayOrder : Command
    {
        public PayOrder(HttpClient httpClient, string path) : base(httpClient, path)
        {
        }

        public override void Execute()
        {
            try
            {
                Console.Write("Enter an order number to pay: ");
                int roomNumber = Convert.ToInt32(Console.ReadLine());
                var requestString = path + "/api/orders/" + roomNumber;
                var result = httpClient.PutAsync(requestString, null).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var updatedOrderString = result.Content.ReadAsStringAsync().Result;
                    var order = JsonConvert.DeserializeObject<Order>(updatedOrderString);
                    Console.WriteLine("The order was sucessfuly paid:");
                    Console.WriteLine($"\n{order.ToString()}\n");
                }
                else
                {
                    var messageString = result.Content.ReadAsStringAsync().Result;
                    var messageResult = JsonConvert.DeserializeObject<RequestMessageResult>(messageString);
                    Console.WriteLine($"\n{messageResult.Message}\n");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input data");
            }
        }
    }
}
