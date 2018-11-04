using System;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            var currentConditionsReport = new CurrentConditionsReport();
            var statisticsReport = new StatisticReport();
            weatherData.Register(currentConditionsReport);
            weatherData.Register(statisticsReport);

            var weatherInfo = new WeatherInfo(){Temperature = 10, Humidity = 15, Pressure = 30};
            weatherData.UpdateWeatherInfo(weatherInfo);

            Console.WriteLine(currentConditionsReport.MakeReport() + "\n\n");
            Console.WriteLine(statisticsReport.MakeReport() + "\n\n");

            weatherInfo.Temperature = -10;
            weatherInfo.Humidity = 3;
            weatherInfo.Pressure = 87;
            weatherData.UpdateWeatherInfo(weatherInfo);

            Console.WriteLine(currentConditionsReport.MakeReport() + "\n\n");
            Console.WriteLine(statisticsReport.MakeReport() + "\n\n");
        }
    }
}
