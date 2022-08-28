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

            // await handle.StopAsync();

            //var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    var host = cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), h =>
            //     {
            //         h.Username(RabbitMqConsts.UserName);
            //         h.Password(RabbitMqConsts.Password);
            //     });

            //    cfg.ReceiveEndpoint(RabbitMqConsts.GreetingQueue, ep =>
            //    {
            //        //ep.PrefetchCount = 16;
            //        //ep.UseMessageRetry(r => r.Interval(5, 100));
            //        //ep.AutoDelete = true;
            //        ep.Consumer<GreetingsConsumer>();
            //    });
            //});

            Console.WriteLine("Listening to your name... Please enter to exit");
            Console.ReadKey();
            await bus.StopAsync();
        }
    }
}
