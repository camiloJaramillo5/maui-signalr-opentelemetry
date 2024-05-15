using MauiAppClient.Services;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace MauiAppClient;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPage>();

        //Include signalR connections.

        var devSslHelper = new DevHttpsConnectionHelper(sslPort: 7007);
        //var devSslHelper = new DevHttpsConnectionHelper(sslPort: 5031); // for http

        CounterHubService.SetConnection(
            new HubConnectionBuilder()
#if ANDROID
            .WithUrl(devSslHelper.DevServerRootUrl + "/counterHub"
            , configureHttpConnection: o =>
            {
                o.HttpMessageHandlerFactory = m => devSslHelper.GetPlatformMessageHandler();
            }
            )
#else
            .WithUrl(devSslHelper.DevServerRootUrl + "/counterHub")
#endif
            .Build());

        StockHubService.SetConnection(
            new HubConnectionBuilder()
#if ANDROID
            .WithUrl(devSslHelper.DevServerRootUrl + "/stockHub"
            , configureHttpConnection: o =>
            {
                o.HttpMessageHandlerFactory = m => devSslHelper.GetPlatformMessageHandler();
            }
            )
#else
            .WithUrl(devSslHelper.DevServerRootUrl + "/stockHub")
#endif
            .Build());


        // Include OpenTelemetry meter provider.
        var meterProvider = Sdk
            .CreateMeterProviderBuilder()
            .AddMeter("counterHubMeter")
            .AddPrometheusHttpListener(options => options.UriPrefixes = new string[] { "http://localhost:9464/" })
            //.AddPrometheusHttpListener(options => options.UriPrefixes = new string[] { "http://10.0.2.2:9464/" }) // for android
            .Build();

        builder.Services.AddSingleton(meterProvider); 

        // Include more OpenTelemetry provider if necessary.

        return builder.Build();
    }
}
