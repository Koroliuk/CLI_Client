using System;
using System.Net;
using System.Net.Http;

namespace ConsoleClient.Commands.OrderCommands
{
    public class DeleteOrder : Command
    {
        public DeleteOrder(HttpClient httpClient, string path) : base(httpClient, path)
        {
        }

        public override void Execute()
        {
            try
            {
                Console.Write("Enter an order number to delete: ");
                int roomNumber = Convert.ToInt32(Console.ReadLine());
                var requestString = path + "/api/orders/" + roomNumber;
                var result = httpClient.DeleteAsync(requestString).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("The order was sucessfuly deleted");
                }
                else
                {
                    Console.WriteLine("Such order was not found");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input data");
            }
        }
    }
}
