using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        public static void SendMail(string to, string subject, string body)
        {
            SendMail(new List<string> { to },new List<string>(), subject, body);
        }
        public static void SendMail(List<string> to,List<string> bcc,string subject,string body)
        {
            string fromAddress = "riteshdoshi229@gmail.com";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromAddress);
            mail.Subject = subject;
            mail.Body = body;
            foreach (string email in to)
            {
                mail.To.Add(email); 
            }
            foreach (string email in bcc)
            {
                mail.Bcc.Add(email);
            }
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("riteshdoshi229@gmail.com", "fsmkqymkvqrrtjxd"),
                EnableSsl = true,
            };

            //client.Host = "mail.server.com";
            //client.Username = "username";
            //client.Password = "password";
            //client.Port = 587;
            //client.SecurityOptions = SecurityOptions.SSLExplicit;

            client.Send(mail);

        }
    }
}
