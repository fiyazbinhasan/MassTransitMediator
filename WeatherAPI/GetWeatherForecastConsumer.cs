using MassTransit;

namespace WeatherAPI;
public class GetWeatherForecastConsumer : IConsumer<GetWeatherForecasts>
{
    private static readonly string[] Summaries = new[] 
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task Consume(ConsumeContext<GetWeatherForecasts> context)
    {
        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();

        await context.RespondAsync<WeatherForecasts>(new
        {
            Forecasts = forecasts
        });
    }
}

public interface GetWeatherForecasts
{
}

public interface WeatherForecasts
{
    WeatherForecast[] Forecasts {  get; }
}