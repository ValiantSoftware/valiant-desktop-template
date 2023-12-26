using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ValiantTemplate.Endpoints;

internal static class DemoEndpoints
{
    public static void MapDemoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/rng", () => Results.Content(Random.Shared.Next(100).ToString()));

        endpoints.MapPost("/api/calc", () =>
        {
            Process.Start("calc");
            return Results.Ok();
        });
    }
}
