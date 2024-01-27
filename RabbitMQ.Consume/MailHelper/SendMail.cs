using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consume.MailHelper
{
    public class SendMail
    {
       
        public static async Task UsersSendMail(string email, string content)
        {
            using (MailMessage mail = new MailMessage())
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    mail.From = new MailAddress("1703dpdeveloper@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Kullanıcılara Mail Gönderme";
                    mail.Body = $"<h2>{email} ' a Gönderilen Mail</h2>";
                    mail.Body += $"<p>{content}</p>";
                    mail.IsBodyHtml = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("1703dpdeveloper@gmail.com", "dvfr dlay lipo ouwz");
                   

                    await smtp.SendMailAsync(mail); 
                }
            }
        }
    }
}
