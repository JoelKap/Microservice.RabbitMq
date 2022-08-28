using MassTransit;
using System;
using System.Threading.Tasks;

namespace Comms.RabbitMq.Consumer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var bus = new RabbitMqBus().Configuration();

            var handle = bus.ConnectReceiveEndpoint(RabbitMqConsts.GreetingQueue, epx =>
             {
                 epx.Consumer<GreetingConsumer>();
             });

            Console.WriteLine("Listening to your name... Please enter to exit");
            Console.ReadKey();
            await bus.StopAsync();
        }
    }
}
