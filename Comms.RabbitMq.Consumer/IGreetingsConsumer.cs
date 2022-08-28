namespace Comms.RabbitMq.Consumer
{
    public interface IGreetingsConsumer
    {
        string FindAndReplaceOutputMessage(string message);
    }
}
