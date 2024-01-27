using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consume
{
    public class RabbitMQHelper : IDisposable
    {
        private static RabbitMQHelper _instance;
        private static readonly object _lockObject = new object();
        private readonly ConnectionFactory _factory;

        private IConnection _connection;

        private IModel _channel;


        public static RabbitMQHelper GetInstance()
        {
            lock (_lockObject)
            {
                return _instance ??= new RabbitMQHelper();
            }
        }
        public RabbitMQHelper()
        {
            _factory = new ConnectionFactory();
            _factory.Uri = new Uri("amqps://qzczcbwb:AkCWf1Ug2_3O0BgnSLoB4Go-cv6Qb5ht@goose.rmq2.cloudamqp.com/qzczcbwb");

            CreateConnectionAndChannel();
            DeclareQueue();

        }

        public async Task SendTextRequest(List<User> users, string content)
        {
            List<Task> sendTasks = new List<Task>();

            foreach (var user in users)
            {
                string message = $"{user.FirstName}|{user.Email}|{content}";
                var body = Encoding.UTF8.GetBytes(message);

                sendTasks.Add(Task.Run(() => _channel.BasicPublish(exchange: "", routingKey: "new-send-mail-request", basicProperties: null, body: body)));
            }

            await Task.WhenAll(sendTasks);
        }


        public void ConsumeMailRequest(Action<string,string,string> onReceived)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                string[] parts = message.Split('|');
                string firstname = parts[0];
                string email = parts[1];
                string content = parts[2];

                onReceived(firstname, email, content);
            };
            _channel.BasicConsume(queue: "new-send-mail-request", autoAck: true, consumer: consumer);
        }





        private void CreateConnectionAndChannel()
        {
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        private void DeclareQueue()
        {
            _channel.QueueDeclare(queue: "new-send-mail-request", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
