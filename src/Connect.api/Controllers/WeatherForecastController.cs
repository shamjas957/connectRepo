using ConnectApi.Core.Commands.WeatherForecast.Request;
using ConnectApi.Core.Commands.WeatherForecast.Response;
using ConnectApi.Core.Common.Enums;
using ConnectApi.Core.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connect.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpPost("AddNewWeather")]
        
        [Authorize(Roles ="Writer")]
        public async Task<WeatherForecastResponse> AddNewWeather([FromBody] WeatherForecastRequest request)
        {
            var result = await mediator.Send<WeatherForecastResponse>(request);

            return result;

        }
    }
}