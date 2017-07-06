
namespace MassTransitLearn
{
    using MassTransit;

    class Program
    {
        static void Main(string[] args)
        {
            var host = "localhost";
            var queue = "test";
            var endpoint = string.Format("rabbitmq://{0}/{1}", host, queue);
            var rabbitEndpoint = new[] { host };
            var bus = ServiceBusFactory.New(sbc =>
            {
                sbc.UseRabbitMq()
            });
        }
    }
}
