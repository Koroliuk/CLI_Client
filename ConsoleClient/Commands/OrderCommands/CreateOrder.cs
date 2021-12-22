using ConsoleClient.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleClient.Commands.OrderCommands
{
    public class CreateOrder : Command
    {
        public CreateOrder(HttpClient httpClient, string path) : base(httpClient, path)
        {
        }

        public override void Execute()
        {
            try
            {
                Console.Write("Enter a start date (yyyy-MM-dd): ");
                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Console.Write("Enter an end date (yyyy-MM-dd): ");
                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Console.Write("Pay now? (y/): ");
                string isPaidString = Console.ReadLine();
                Console.Write("Enter a room number: ");
                int roomNumber = Convert.ToInt32(Console.ReadLine());

                var newOrder = new Order
                {
                    Start = startDate,
                    End = endDate,
                    Type = isPaidString.Trim() == "y" ? OrderType.Paid : OrderType.Booked,
                    RoomNumber = roomNumber
                };

                var orderJson = JsonConvert.SerializeObject(newOrder);
                var body = new StringContent(orderJson, Encoding.UTF8, "application/json");

                var requestString = path + "/api/orders/" + roomNumber;
                var result = httpClient.PostAsync(requestString, body).Result;
                if (result.StatusCode == HttpStatusCode.Created)
                {
                    var createdOrderString = result.Content.ReadAsStringAsync().Result;
                    var order = JsonConvert.DeserializeObject<Order>(createdOrderString);
                    Console.WriteLine("The order was sucessfuly created:");
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
