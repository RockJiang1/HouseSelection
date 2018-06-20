using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;

namespace HouseSelection.KeepAlive
{
    public partial class KeepAliveService : ServiceBase
    {
        private Thread ThdPrivateInterface;
        private Thread ThdPublicInterface;
        private Thread ThdFrontEndInterface;

        private int Interval = 10 *60 * 1000;

        public KeepAliveService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ThdPrivateInterface = new Thread(new ThreadStart(PrivateInterfaceTimer));
            ThdPublicInterface = new Thread(new ThreadStart(PublicInterfaceTimer));
            ThdFrontEndInterface = new Thread(new ThreadStart(FrontEndInterfaceTimer));

            ThdPrivateInterface.Start();
            ThdPublicInterface.Start();
            ThdFrontEndInterface.Start();
        }

        protected override void OnStop()
        {
        }

        private void PrivateInterfaceTimer()
        {
            NetworkClient Client = new NetworkClient();

            while (true)
            {
                try
                {
                    var res = Client.InvokeAPI<BaseResultEntity>(new PrivateAPIRequest());
                    Logger.LogDebug("PrivateInterface Keep Alive Successfully.", "KeepAliveService", "PrivateInterfaceTimer");
                }
                catch(Exception ex)
                {
                    Logger.LogException("PrivateInterface Keep Alive Exception:", "KeepAliveService", "PrivateInterfaceTimer", ex);
                }
                Thread.Sleep(Interval);
            }
        }

        private void PublicInterfaceTimer()
        {
            NetworkClient Client = new NetworkClient();

            while (true)
            {
                try
                {
                    var res = Client.InvokeAPI<BaseResultEntity>(new PublicAPIRequest());
                    Logger.LogDebug("PublicInterface Keep Alive Successfully.", "KeepAliveService", "PublicInterfaceTimer");
                }
                catch (Exception ex)
                {
                    Logger.LogException("PublicInterface Keep Alive Exception:", "KeepAliveService", "PublicInterfaceTimer", ex);
                }
                Thread.Sleep(Interval);
            }
        }

        private void FrontEndInterfaceTimer()
        {
            NetworkClient Client = new NetworkClient();

            while (true)
            {
                try
                {
                    var res = Client.InvokeAPI<BaseResultEntity>(new FrontEndAPIRequest());
                    Logger.LogDebug("FrontEndInterface Keep Alive Successfully.", "KeepAliveService", "FrontEndInterfaceTimer");
                }
                catch (Exception ex)
                {
                    Logger.LogException("FrontEndInterface Keep Alive Exception:", "KeepAliveService", "FrontEndInterfaceTimer", ex);
                }
                Thread.Sleep(Interval);
            }
        }
    }
}
