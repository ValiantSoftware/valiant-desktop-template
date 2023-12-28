using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using ValiantTemplate.Endpoints;

namespace ValiantTemplate;

public static class ServerBuilder
{
    public static WebApplication BuildWebApplication()
    {
        var builder = WebApplication.CreateSlimBuilder();
        if (Program.IsDebug)
        {
            builder.Logging.AddDebug();
        }

        ServerUrl.SetForBuilder(builder);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        var app = builder.Build();

        // When running in debug, we connect to the Vite dev server, rather than using the
        // embedded resources (which are not even included in debug builds). So we don't
        // need to bother wiring up static files etc.
        if (!Program.IsDebug)
        {
            app.UseFileServer(new FileServerOptions()
            {
                EnableDefaultFiles = true,
                FileProvider = new ManifestEmbeddedFileProvider(typeof(Program).Assembly, "/wwwroot"),
            });
        }

        app.UseRouting();
        app.MapDemoEndpoints();

        app.MapFallbackToFile("index.html");

        return app;
    }
}
