using CG.Alerts.Options;
using Microsoft.Extensions.Hosting;
using System;

namespace CG.Alerts.QuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureApplicationOptions<ApplicationOptions>()
                .Build()
                .SetStandardAlertHandler()
                .RunDelegate(host =>
                {
                    Alert.Instance().RaiseInformation("hosted information alert.");

                    Console.WriteLine("press any key to exit");
                    Console.ReadKey();
                });                    
        }
    }
}
