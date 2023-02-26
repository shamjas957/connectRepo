using ConnectApi.Core.Commands.WeatherForecast.Request;
using FluentValidation;

namespace ConnectApi.Core.Commands.WeatherForecast.Validators
{
    public class WeatherForecastRequestValidator: AbstractValidator<WeatherForecastRequest>
    {
        public WeatherForecastRequestValidator()
        {
            RuleFor(i => i.Summary).NotEmpty();
            RuleFor(i => i.Date).GreaterThan(DateTime.Now.AddDays(-1));
            RuleFor(i => i.TemperatureC).GreaterThan(0);
        }
    }
}
