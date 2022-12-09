using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MegCubeService
{
    public class SendRequest
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void Check()
        {
            var urlToCheck = context.UserUrls.ToList();

            foreach (var item in urlToCheck)
            {
                PostRequest(item.Value);
            }
        }
        public void PostRequest(string url)
        {

            try
            {
                var client = new RestClient(url);
                WebRequest myWebRequest = HttpWebRequest.Create(url);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
                var request = new RestRequest(Method.GET);
                RestResponse response = (RestResponse)client.Execute(request);

                context.Logs.Add(new DiasService.Entities.Logs
                {
                    Status = ((int)response.StatusCode).ToString(),
                    StoreDate = DateTime.Now,
                    Url = url,
                    Value = response.Content
                });
                context.SaveChanges();

                if (!response.IsSuccessful)
                {
                    string message = $"URL : {url} - Status Code: {((int)response.StatusCode)} - Description: {response.StatusDescription}";

                    MailGonder(message);
                }

            }
            catch (Exception ex)
            {
                MailGonder(ex.Message.ToString());
                context.Logs.Add(new DiasService.Entities.Logs
                {
                    Status = "500",
                    StoreDate = DateTime.Now,
                    Url = url,
                    Value = ex.Message.ToString()
                });
                context.SaveChanges();
            }
        }
        public bool MailGonder(string body, string subject = "Down Notifier")
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp-mail.Outlook.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("kadirrceyhann@gmail.com", "45502235444KC");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("kadirrceyhann@gmail.com");
            mailMessage.To.Add("kadirceyhan395@gmail.com");
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
