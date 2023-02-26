using ConnectApi.Core.Helpers.Implementations.WeatherForecast;
using ConnectApi.Core.Helpers.Interfaces.WeatherForecast;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RegisterCore
    {
        public static IServiceCollection RegisterHelper(this IServiceCollection services)
        {
            return services
                .AddScoped<IWeatherforecastLogic, WeatherforecastLogic>()
                .AddScoped<IWeatherForecastCalculator, WeatherForecastCalculator>();
        }

    }
}
