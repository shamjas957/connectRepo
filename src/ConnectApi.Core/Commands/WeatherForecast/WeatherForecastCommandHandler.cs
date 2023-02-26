using ConnectApi.Core.Commands.WeatherForecast.Request;
using ConnectApi.Core.Commands.WeatherForecast.Response;
using ConnectApi.Core.Commands.WeatherForecast.Validators;
using ConnectApi.Core.Common.Exceptions;
using ConnectApi.Core.Helpers.Interfaces.WeatherForecast;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectApi.Core.Handlers.WeatherForecast
{
    public class WeatherForecastCommandHandler : IRequestHandler<WeatherForecastRequest, WeatherForecastResponse>
    {
        private readonly ILogger<WeatherForecastCommandHandler> _logger;
        private readonly IWeatherforecastLogic _weatherforecastLogic;
        private readonly IWeatherForecastCalculator _weatherForecastCalculator;

        public WeatherForecastCommandHandler(ILogger<WeatherForecastCommandHandler> logger,
            IWeatherforecastLogic weatherforecastLogic,
            IWeatherForecastCalculator weatherForecastCalculator)
        {
            _logger = logger;
            _weatherforecastLogic = weatherforecastLogic;
            _weatherForecastCalculator = weatherForecastCalculator;
        }


        public async  Task<WeatherForecastResponse> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var validator = new WeatherForecastRequestValidator().Validate(request);
            if (!validator.IsValid)
            {
                _logger.LogError("Validation failed");
                throw new InputValidationException(validator.ToString())
                {
                    Details = request.ToString()
                };
            }
            _logger.LogInformation("Validation success");

            //Test calls
            await _weatherForecastCalculator.CalculateWeather(request.TemperatureC, 2);
            await _weatherforecastLogic.ConvertToFarenhiet(100);




           

            return new WeatherForecastResponse
            {
                Response = "Saved"
            };
            //return Task.FromResult(new WeatherForecastResponse
            //{
            //    Response= "Saved"
            //});
        }
    }
}
