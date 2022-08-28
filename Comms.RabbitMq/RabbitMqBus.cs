using MassTransit;
using System;

namespace Comms.RabbitMq
{
    public class RabbitMqBus
    {
        public IBusControl Configuration()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), hst =>
                {
                    hst.Username(RabbitMqConsts.UserName);
                    hst.Password(RabbitMqConsts.Password);
                });
            });

            bus.Start();
            return bus;
        }
    }
}
