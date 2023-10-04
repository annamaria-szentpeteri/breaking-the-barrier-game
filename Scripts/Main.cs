using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingTheBarrier.Scripts
{
    public class Main
    {
        public void OnStart()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddSingleton();

            var host = builder.Build();
            host.Start();
            host.WaitForShutdown();
        }
    }
}
