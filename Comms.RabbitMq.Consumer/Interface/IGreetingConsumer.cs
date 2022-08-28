namespace Comms.RabbitMq.Consumer
{
    public interface IGreetingConsumer
    {
        string FindAndReplaceOutputMessage(string message);
    }
}
 