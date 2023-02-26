namespace ConnectApi.Core.Helpers.Interfaces.WeatherForecast
{
    public interface IWeatherforecastLogic
    {
        Task<int> ConvertToFarenhiet(int temperature);
    }
}