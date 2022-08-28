using Comms.RabbitMq.Consumer;
using Comms.RabbitMq.Message;
using MassTransit;
using MassTransit.Testing;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Comms.RabbitMq.Test
{
    [TestFixture] 
    public class Tests
    {
        [Test]
        public async Task SHOULD_START_AND_STOP_THE_TEST_HARNESS()
        {
            //Arrange
            var harness = new InMemoryTestHarness();

            await harness.Start();
            await harness.Stop();
        } 

        [Test] 
        public async Task GIVEN_SETUP_IS_CORRECT_SHOULD_TEST_THE_CONSUMER()
        {
            //Arrange
            var harness = new InMemoryTestHarness();
            var consumerHarness = harness.Consumer<GreetingConsumer>();

            await harness.Start();
            try 
            {
                //Act
                await harness.InputQueueSendEndpoint.Send(new Greeting("Uncle Bob"));
                 
                //Assert
                Assert.IsTrue(harness.Consumed.Select<Greeting>().Any());
                Assert.IsTrue(consumerHarness.Consumed.Select<Greeting>().Any());
            }
            finally
            {
                await harness.Stop();
            }
        }

        [Test]
        public async Task GIVEN_SETUP_IS_CORRECT_CONSUMER_SHOULD_NOT_THROW_EXEPTION()
        {
            //Arrange
            var harness = new InMemoryTestHarness();
            
            await harness.Start();
            try
            {
                //Act
                await harness.InputQueueSendEndpoint.Send(new Greeting("Uncle Bob"));

                //Assert
                Assert.IsFalse(harness.Published.Select<Fault<Greeting>>().Any());
            }
            finally
            {
                await harness.Stop();
            }
        }
    }
}