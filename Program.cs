using System;
using System.Net.Mail;

namespace SMTP_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\pathToFile\MyFile.txt";

            MyFileReader fr = new MyFileReader(path);

            string from = fr.from;
            string to = fr.to;

            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = fr.subject;
            mailMessage.Body = fr.content;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);


            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(from, fr.password);
            smtpClient.EnableSsl = true;

            try
            {
                Console.WriteLine("Sending email...");
                smtpClient.Send(mailMessage);
                smtpClient.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: {0}", ex.ToString());
            }

            Console.WriteLine("Email sent!");
        }
    }
}
