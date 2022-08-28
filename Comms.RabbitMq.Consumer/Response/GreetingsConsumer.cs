using Comms.RabbitMq.Message;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Comms.RabbitMq.Consumer.Response
{
    public class GreetingsConsumer : IConsumer<Greeting>
    {
        public async Task Consume(ConsumeContext<Greeting> context)
        {
            var message = context.Message?.Name;

            if (!string.IsNullOrWhiteSpace(message))
            {
                message = message.Replace("Hello my name is,", "Hello");
                await Console.Out.WriteLineAsync($"{message }");
            }
            else
            {
                await Console.Out.WriteLineAsync($"Please contact your admin!");
            }
        }
    }
}
