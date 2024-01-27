//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Core
//{
//    public class SendMailRequestHandler
//    {
//        private RabbitMQHelper _rabbitMQHelper;

//        public SendMailRequestHandler(RabbitMQHelper rabbitMQHelper)
//        {
//            _rabbitMQHelper = rabbitMQHelper;
//        }

//        public void StartHandling()
//        {
//            _rabbitMQHelper.ConsumeMailRequest((firstname, email, content) =>
//            {
//                Task.Run( async() =>
//                {
//                   await MailHelper.SendMail.UsersSendMail(email, content);
//                });
//            });
//        }


//    }
//}
