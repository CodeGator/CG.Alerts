using CG.Applications.Options;
using CG.Options;
using Microsoft.Extensions.Hosting;
using System;

namespace CG.Applications.QuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Instance()
                .RunOnce<Program>(() =>
                {
                    Host.CreateDefaultBuilder()
                        .ConfigureApplicationOptions<ApplicationOptions>()
                        .Build()
                        .SetStandardAlertHandler()
                        .RunDelegate(host =>
                        {
                            Alert.Instance().RaiseInformation("information alert.");

                            Console.WriteLine("press any key to exit");
                            Console.ReadKey();
                        });                    
                });
        }
    }
}
