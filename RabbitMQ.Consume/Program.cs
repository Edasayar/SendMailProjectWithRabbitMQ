using RabbitMQ.Consume;
using RabbitMQ.Consume.Data;
using RabbitMQ.Consume.MailHelper;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RabbitMQ.Consume
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var rabbitMQHelper = RabbitMQHelper.GetInstance())
            {

                var dataModel = new DataModel();
                List<User> users = dataModel.GetData().ToList();

                Timer timer = new Timer(CheckForMessages, rabbitMQHelper, TimeSpan.Zero, TimeSpan.FromSeconds(5));

                rabbitMQHelper.ConsumeMailRequest((firstname, email, mailContent) =>
                {
                    SendMail.UsersSendMail(email, mailContent);
                    Console.WriteLine($"Mail {email} adresine  gönderildi");
                });

                Console.WriteLine("Çıkmak için bir tuşa basın");
                Console.ReadKey();

                timer.Dispose();
            }


        }

        private static void CheckForMessages(object state)
        {
            var rabbitMQHelper = (RabbitMQHelper)state;

            rabbitMQHelper.ConsumeMailRequest((firstname, email, mailContent) =>
            {
                SendMail.UsersSendMail(email, mailContent);
                Console.WriteLine($"Mail {email} adresine  gönderildi");
            });
        }
    }
}
