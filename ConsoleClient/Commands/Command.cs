using System.Net.Http;

namespace ConsoleClient.Commands
{
    public abstract class Command
    {
        protected readonly HttpClient httpClient;
        protected readonly string path;

        protected Command(HttpClient httpClient, string path)
        {
            this.httpClient = httpClient;
            this.path = path;
        }

        public abstract void Execute();
    }
}
