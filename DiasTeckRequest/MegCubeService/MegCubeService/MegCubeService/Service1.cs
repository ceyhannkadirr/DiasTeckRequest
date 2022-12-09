using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading;

namespace MegCubeService
{
    public partial class Service1 : ServiceBase
    {
        SendRequest sendRequest = new SendRequest();
        public Service1()
        {
            InitializeComponent();

        }
        public void ServiceInit()
        {
            OnStart(null);

        }

        protected override void OnStart(string[] args)
        {
            Thread thread2 = new Thread(new ThreadStart(ThreadFuncEven2));
            thread2.Start();
        }

        private void ThreadFuncEven2()
        {
            while (true)
            {
                sendRequest.Check();
                Thread.Sleep(5000);
            }
        }

        protected override void OnStop()
        {
            Console.WriteLine("servis durduruldu");
        }
    }
}
