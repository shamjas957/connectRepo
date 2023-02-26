using ConnectApi.Core.Common.Exceptions;
using ConnectApi.Core.Helpers.Interfaces.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectApi.Core.Helpers.Implementations.WeatherForecast
{
    public class WeatherForecastCalculator : IWeatherForecastCalculator
    {

        public async Task<int> CalculateWeather(int temperature, int total)
        {
            try
            {

                return total / temperature;
            }
            catch (Exception ex)
            {
                throw new ReturnMessageToCallerExceptions($"Failed While Calculating Weather")
                {
                    Details=$"MethodName: {nameof(CalculateWeather)}, temperature:{temperature}, Total:{total}"
                };
            }
        }
    }
}
