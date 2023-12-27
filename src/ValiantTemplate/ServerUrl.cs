using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;

namespace ValiantTemplate;

internal static class ServerUrl
{
    private const string ProductionServer = "http://127.0.0.1:0";
    private const string DevelopmentApi = "http://localhost:8195";
    private const string DevelopmentFrontEnd = "http://localhost:8196";

    public static void SetForBuilder(WebApplicationBuilder builder)
    {
        if (Program.IsDebug)
        {
            builder.WebHost.UseUrls(DevelopmentApi);
        }
        else
        {
            builder.WebHost.UseUrls(ProductionServer);
        }
    }

    public static string GetFromApp(WebApplication app)
    {
        if (Program.IsDebug)
        {
            return DevelopmentFrontEnd;
        }

        var server = app.Services.GetService<IServer>();
        if (server is null)
        {
            throw new Exception("Unable to resolve web server details.");
        }

        var serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();
        if (serverAddressesFeature is null)
        {
            throw new Exception("Unable to resolve web server address details.");
        }

        var address = serverAddressesFeature.Addresses.FirstOrDefault();
        if (address is null)
        {
            throw new Exception("Unable to resolve web server address.");
        }

        return address;
    }
}
