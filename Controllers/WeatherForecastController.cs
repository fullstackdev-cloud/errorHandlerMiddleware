using errorHandlerMiddleware.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace errorHandlerMiddleware.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Trying to do something stupid.");
        throw new YouDidSomethingStupidException("Oops, something broke.");
    }
}
