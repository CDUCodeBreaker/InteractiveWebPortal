using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EmailHelper
    {
        public void SendMail(string Email)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "hasanmukit009@gmail.com";
            // any address where the email will be sending
            var toAddress = "farajisuman@gmail.com";
            //Password of your gmail address
            const string fromPassword = "#Bangladesh1971#";
            // Passing the values and make a email formate to display
            string subject = "Please activate this account + Download : <a href='" + Email + "'></a>";
            string body = "From: " + "Mahamud Hasan" + "\n";
            body += "Email: " + "hasanmukit009@gmail.com" + "\n";
            body += "Subject: " + "Welcome to community web portal" + "\n" + "Please <a href=\'" + Email + "' > login</a>";
            //body += "Question: \n" + "Be part of the community" + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        public void SendEmailWithAttachment(string fullfilepath, string MailTo, string Subject, string Body)
        {
            Collection<string> MailAttachments = new Collection<string>();
            if (fullfilepath != "")
            {
                MailAttachments.Add(fullfilepath);
            }
            using (MailMessage mm = new MailMessage("hasanmukit009@gmail.com", MailTo))
            {
                mm.Subject = Subject;
                mm.Body = Body;
                if (MailAttachments.Count > 0)
                {
                    foreach (string filePath in MailAttachments)
                    {
                        Attachment attachment = new Attachment(filePath);
                        mm.Attachments.Add(attachment);
                    }
                }
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("hasanmukit009@gmail.com", "#Bangladesh1971#");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}
