using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceDias
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (timer == null)
            {
                timer = new Timer();
            }
            timer.Interval = 10000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
        }

        protected override void OnStop()
        {
        }
        public bool MailGonder()
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "Smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("kadirrceyhann@gmail.com", "45502235444KC");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("kadirrceyhann@gmail.com");
            mailMessage.To.Add("kadirceyhann@yandex.com");
            mailMessage.Subject = "deneme";
            mailMessage.Body = "deneme içerik";
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
