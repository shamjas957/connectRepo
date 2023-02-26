using ConnectApi.Core.Commands.WeatherForecast.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectApi.Core.Commands.WeatherForecast.Request
{
    public class WeatherForecastRequest : IRequest<WeatherForecastResponse>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public override string ToString()
        {
            return $"Date:{Date}, TemperatureC:{TemperatureC}, Summary:{Summary}";
        }
    }
}
