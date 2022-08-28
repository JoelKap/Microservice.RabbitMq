using Comms.RabbitMq.Message;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Comms.RabbitMq.Consumer
{
    public class GreetingsConsumer : IConsumer<Greeting>, IGreetingsConsumer
    {
        public async Task Consume(ConsumeContext<Greeting> context)
        {
            var message = context.Message?.Name;

            if (!string.IsNullOrWhiteSpace(message))
            {
                await Console.Out.WriteLineAsync($"{FindAndReplaceOutputMessage(message)}");
            }
            else
            {
                await Console.Out.WriteLineAsync($"Please contact your admin!");
            }
        }

        public string FindAndReplaceOutputMessage(string message)
        {
            return message.Replace("Hello my name is,", "Hello");
        }
    }
}
