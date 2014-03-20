using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace MP_WService
{
    public partial class MyService : ServiceBase
    {
        protected System.Timers.Timer gTimer = new System.Timers.Timer();
        private log4net.ILog gInfoLogger = log4net.LogManager.GetLogger("MP_WS_info");
        private log4net.ILog gDebugLogger = log4net.LogManager.GetLogger("MP_WS_debug");

        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //setup the timer interval
            gTimer.Interval = 10000;//10seconds
            //Enable the timer
            gTimer.Enabled = true;
            //Start the timer
            gTimer.Start();
            if (gInfoLogger.IsInfoEnabled == true)
            {
                gInfoLogger.Info("Timer Started");
            }
            //Fire the elapsed event
            gTimer.Elapsed += new System.Timers.ElapsedEventHandler(gtimer_elapsed);


        }

        protected override void OnStop()
        {
        }

        //This is fired when the timer is elapsed
        protected void gtimer_elapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {
            if (gInfoLogger.IsInfoEnabled == true)
            {
                gInfoLogger.Info("Timer Elapsed");
            }
            //stop the timer
            gTimer.Stop();

            // Do some real work
            if (gInfoLogger.IsInfoEnabled == true)
            {
                gInfoLogger.Info("Stop the timer and do some real work");
            }

            if (gInfoLogger.IsInfoEnabled == true)
            {
                gInfoLogger.Info("Timer Re-Started");
            }
            //Happy - Restart the timer 
            gTimer.Start();
            
        }
    }
}
