using RabbitMQ.Client;
using System;
using System.Text;

namespace earth.Producer
{
    public class ProducerRabbitMQ
    {
        public static void Produce()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "better-cambridge-library",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
                string message = string.Empty;
                int count = 0;
                while (true)
                {
                    message = $"{count++} Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                        routingKey: "better-cambridge-library",
                                        basicProperties: null,
                                        body: body);

                    Console.WriteLine(" [x] Sent {0}", message);
                    System.Threading.Thread.Sleep(200);
                }
            }
        }
    }
}