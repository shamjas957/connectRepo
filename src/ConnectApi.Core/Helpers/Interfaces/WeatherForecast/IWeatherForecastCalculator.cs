namespace ConnectApi.Core.Helpers.Interfaces.WeatherForecast
{
    public interface IWeatherForecastCalculator
    {
        Task<int> CalculateWeather(int temperature, int total);
    }
}