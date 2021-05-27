using System;
using System.Net.Mail;
using System.Net;


namespace securityalarm
{
    class Program
    {
        static void Main(string[] args)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
{
    Port = 587,
    Credentials = new NetworkCredential("email", "password"),
    EnableSsl = true,
};
    
smtpClient.Send("email", "recipient", "subject", "body");
        }
    }
}
