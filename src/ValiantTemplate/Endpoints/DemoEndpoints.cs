using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ValiantTemplate.Endpoints;

public static class DemoEndpoints
{
    public static void MapDemoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/rng", () =>
        {
            var model = new DemoResponseModel() { RandomNumber = Random.Shared.Next(100) };
            return Results.Ok(model);
        });

        endpoints.MapPost("/api/calc", () =>
        {
            Process.Start("calc");
            return Results.Ok();
        });
    }
}
