using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassTransitLearn
{
    using MassTransit;

    public interface IBusConfiguration
    {
        void PublishAt(string host, string queue, int concurrentConsumers);
    }

    class Class1: IBusConfiguration
    {
        public void PublishAt(string host, string queue, int concurrentConsumers)
        {
            var bus = ServiceBusFactory.New(sbc =>
            {
                sbc.UseRabbitMq(x=>x.)
            });
        }
        
    }
}
