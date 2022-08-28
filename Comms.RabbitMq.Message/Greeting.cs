namespace Comms.RabbitMq.Message
{
    public class Greeting: IGreeting
    {
        public Greeting(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
