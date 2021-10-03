using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var client = _mediator.CreateRequestClient<GetWeatherForecasts>();

            var response = await client.GetResponse<WeatherForecasts>(new { });
            return response.Message.Forecasts;
        }
    }
}