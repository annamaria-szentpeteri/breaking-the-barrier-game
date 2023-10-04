using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

public class DIContainer
{
    private static IServiceProvider ServiceProvider;

    public DIContainer()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddSingleton<IDialogProvider, DialogProvider>();
        builder.Services.AddSingleton<IAlphabetManager, AlphabetManager>();

        var host = builder.Build();
        host.Start();

        // TODO make this thread safe / race safe
        ServiceProvider = host.Services;
    }

    public static T GetService<T>()
    {
        return ServiceProvider.GetService<T>();
    }
}
