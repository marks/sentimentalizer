using System;
using System.Configuration;
using System.IO;
using System.Web;
using tinyweb.framework;

namespace Sentimentalizer.Api
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var positivePath = ConfigurationManager.AppSettings["PositiveDataPath"];
            var negativePath = ConfigurationManager.AppSettings["NegativeDataPath"];

            Analyser.TrainPositive(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, positivePath));
            Analyser.TrainNegative(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, negativePath));
            
            Tinyweb.Init();
        }
    }
}