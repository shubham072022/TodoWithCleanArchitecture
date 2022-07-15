using Microsoft.AspNetCore.Mvc;
using Todo.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Todo.API.Controllers
{
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastQuery());
        }
    }
}