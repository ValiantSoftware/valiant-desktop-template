using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using ValiantTemplate.Endpoints;

namespace ValiantTemplate;

internal static class ServerBuilder
{
    public static WebApplication BuildWebApplication()
    {
        var builder = WebApplication.CreateSlimBuilder();

        ServerUrl.SetForBuilder(builder);

        var app = builder.Build();

        app.UseFileServer(new FileServerOptions()
        {
            EnableDefaultFiles = true,
            FileProvider = new ManifestEmbeddedFileProvider(typeof(Program).Assembly, "/wwwroot"),
        });

        app.UseRouting();
        app.MapDemoEndpoints();

        app.MapFallbackToFile("index.html");

        return app;
    }
}
