using RabbitMQ.Client;
using System.Text;

namespace UdemyRabbitMQ.Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory();

            connectionFactory.Uri = new Uri("amqps://cvdsmplc:rPV4bmv5QDAJXd8oe-25QULUW9BdA-wT@rat.rmq2.cloudamqp.com/cvdsmplc");


            using var connection = connectionFactory.CreateConnection();
            
            
            var channel = connection.CreateModel();
            channel.QueueDeclare("hello-queue", true, false, false);

            string message = "hello world";
            var messageBody = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);

            Console.WriteLine("Mesaj Gönderilmiştir.");
            Console.ReadKey();
        }
    }
}
