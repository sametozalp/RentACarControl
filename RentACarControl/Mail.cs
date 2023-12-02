using System.Net;
using System.Net.Mail;

namespace RentACarControl
{
    internal class Mail
    {
        public Mail() {
            smtpClient = new SmtpClient(smtpServer);
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;
            mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
        }

        public void sendMail(string title, string body, List<User> recipientList)
        {
            try
            {
                mailMessage.Subject = title;
                mailMessage.Body = body;

                foreach (User recipient in recipientList)
                {
                    if(recipient.getMail() != "" && recipient.getDate() == DateTime.Now.Date)
                        mailMessage.To.Add(recipient.getMail());
                }

                smtpClient.Send(mailMessage);
                Console.WriteLine("E-posta başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
        }

        string senderEmail = "rentacar.43@hotmail.com";
        string senderPassword = "rentacar43";
        string smtpServer = "smtp.office365.com";
        int smtpPort = 587;
        SmtpClient smtpClient;
        MailMessage mailMessage;
    }
}