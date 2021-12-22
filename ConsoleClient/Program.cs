using ConsoleClient.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        private const string APP_PATH = "http://localhost:50118";

        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            Launcher launcher = new Launcher(httpClient, APP_PATH);
            launcher.Start();
        }
    }
}
