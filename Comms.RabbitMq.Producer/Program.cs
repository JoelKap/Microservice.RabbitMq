using Comms.RabbitMq.Message;
using System;
using System.Threading.Tasks;

namespace Comms.RabbitMq.Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bus = new RabbitMqBus().Configuration();
            
            Console.WriteLine("Please type your name:");
            var name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Incorrect value, Please try again");
                name = Console.ReadLine();
            }

            await bus.Publish(new Greeting($"Hello my name is, {name}"));

            await bus.StopAsync();
        }
    }
}
