using MinimalAPI.Endpoints.Internal;

namespace MinimalAPI.Endpoints;

public class WeatherForceast : IEndpoints
{



    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        //throw new NotImplementedException();
        //Put any singleton service or configurations here now. 
    }

    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {

        
        app.MapGet("/weatherforecast", GetWeatherForcast)
        .WithName("GetWeatherForecast")
        .Produces(200);
    }

    internal static async Task<IResult> GetWeatherForcast()
    {
        var summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
        //httpContext.VerifyUserHasAnyAcceptedScope();

        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateTime.Now.AddDays(index),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return Results.Ok(forecast);
    }
    internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
