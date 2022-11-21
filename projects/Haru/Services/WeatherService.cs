using Haru.Models.EFT.Weather;

namespace Haru.Services
{
    public static class WeatherService
    {
        public static WeatherModel GetWeather()
        {
            // note: dumped EFT server data
            return new WeatherModel
            {
                Weather = new WeatherSettingsModel
                {
                    Timestamp = 1661544903,
                    Cloud = -0.091f,
                    WindSpeed = 3,
                    WindDirection = 7,
                    WindGustiness = 0.038f,
                    Rain = 1,
                    RainIntensity = 0f,
                    Fog = 0.002f,
                    Temperature = 13,
                    Date = "2022-08-26",
                    Time = "2022-08-26 23:15:03"
                },
                Date = "2022-08-26",
                Time = "02:12:23",
                Acceleration = 7
            };
        }
    }
}