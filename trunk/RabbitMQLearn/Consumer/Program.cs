using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQHelper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = BusBuilder.GetConnectionFactory();
            using (var conn = factory.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    channel.BasicQos(0, 1, false);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("hello", false, consumer);
                    Console.WriteLine(" waiting for message.");
                    while (true)
                    {
                        string response = null;
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var props = ea.BasicProperties;
                        var replyProps = channel.CreateBasicProperties();
                        replyProps.CorrelationId = props.CorrelationId;
                        var message = Encoding.UTF8.GetString(body);


                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);

                        Console.WriteLine("Received {0}", message);

                        response = message + " has received！";
                        var responseBytes = Encoding.UTF8.GetBytes(response);
                        channel.BasicPublish(exchange: "",
                                             routingKey: props.ReplyTo,
                                             basicProperties: replyProps,
                                             body: responseBytes);
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                }
            }
        }
    }
}
