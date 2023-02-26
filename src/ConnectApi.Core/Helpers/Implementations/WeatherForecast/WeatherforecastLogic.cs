using ConnectApi.Core.Helpers.Interfaces.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectApi.Core.Helpers.Implementations.WeatherForecast
{
    public class WeatherforecastLogic : IWeatherforecastLogic
    {
        public async Task<int> ConvertToFarenhiet(int temperature)
        {
            return temperature;
        }
    }
}
