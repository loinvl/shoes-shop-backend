
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace TheShoesShop_BackEnd.Utils
{
    public class SendingEmail
    {
        private readonly IConfiguration _config;

        public  SendingEmail(IConfiguration config) 
        { 
            _config = config;
        }

        public async Task<bool> SendToEmail(string ToEmail, string Subject, string Content)
        {
            try
            {
                var FromEmail = _config["Email:Gmail:Address"];
                var EmailPassword = _config["Email:Gmail:Password"];

                var HtmlContent = $"<!DOCTYPE " +
                    $"html>\r\n<html lang=\"en\">\r\n" +
                    $"<head>\r\n    " +
                    $"<meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    " +
                    $"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
                    $"<title>Document</title>\r\n</head>\r\n" +
                    $"<body>\r\n {Content} \r\n</body>\r\n" +
                    $"</html>";
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Sender Name", FromEmail));
                message.To.Add(new MailboxAddress(ToEmail, ToEmail));
                message.Subject = Subject;
                message.Body = new TextPart("html") { Text = Content };

                using var smtpClient = new SmtpClient();
                await smtpClient.ConnectAsync("smtp.gmail.com", 465, true);
                await smtpClient.AuthenticateAsync(FromEmail, EmailPassword);
                await smtpClient.SendAsync(message);
                await smtpClient.DisconnectAsync(true);

                Console.WriteLine("Sending email process has done");
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sending email process has failed");
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
