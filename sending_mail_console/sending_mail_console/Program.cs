using System;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace sending_mail_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("--------Mail sending app-------\n" +
                "Sign in : \n" +
                "Enter your e-mail address : ");
            string from = Console.ReadLine();
            
            string server = ";";
            

            Console.Write("Enter your password : ");
            string password = Console.ReadLine();

            Console.Write("Enter the e-mail address to which you will send the message. : ");
            string to = Console.ReadLine();

            Console.Write("Enter the subject of the message : ");
            string subject = Console.ReadLine();

            Console.Write("Enter the body of the message : ");
            string body = Console.ReadLine();





            Console.ReadKey();
        }

        public static string server(string mail)
        {
            int atSymbolIndex = mail.IndexOf("@");
            string server = mail.Substring(atSymbolIndex + 1);
            Dictionary<string,int> server_port = new Dictionary<string,int>();
            server_port.Add("smtp.live.com", 465);
            server_port.Add("smtp-mail.outlook.com", 587);
            server_port.Add("smtp.yandex.com.tr", 465);
            server_port.Add("smtp.mail.yahoo.com", 465);

            Dictionary<string, string> mail_server = new Dictionary<string, string>();
            mail_server.Add("hotmial.com", "smtp.live.com");
            mail_server.Add("outlook.com", "smtp.live.com");
            mail_server.Add("yandex.com", "smtp.live.com");
            mail_server.Add("yahoo.com", "smtp.live.com");




            return server;
        }

        // E-posta gönderme fonksiyonu
        public static void SendEmail(string from , string password, string to,
                             string host,int port, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = host;
            smtp.Port = port;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(from, password);
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mail);
                Console.WriteLine("E-Posta gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-Posta gönderimi başarısız oldu : " + ex.Message);
            }
        }
    }
}
