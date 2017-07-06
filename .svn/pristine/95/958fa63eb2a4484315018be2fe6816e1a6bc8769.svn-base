using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQHelper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer
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
                    var replyQueueName = channel.QueueDeclare().QueueName;
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queue: replyQueueName,
                                         noAck: true,
                                         consumer: consumer);
                    var corrId = Guid.NewGuid().ToString();
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;
                    properties.ReplyTo = replyQueueName;
                    properties.CorrelationId = corrId;
                    string msg = "";
                    do
                    {
                        msg = Console.ReadLine();
                        var body = Encoding.UTF8.GetBytes(msg);
                        channel.BasicPublish("", "hello", properties, body);
                        Console.WriteLine(" has send: {0}", msg);

                        while (true)
                        {
                            var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                            if (ea.BasicProperties.CorrelationId == corrId)
                            {
                                string retrunBody = Encoding.UTF8.GetString(ea.Body);
                                Console.WriteLine(retrunBody);
                                break;
                            }
                        }
                    } while (msg != "0");

                    
                }
            }
            
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
