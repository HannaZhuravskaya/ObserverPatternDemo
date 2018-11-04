using System;
using System.Globalization;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : Report
    {
        public CurrentConditionsReport()
        {
        }

        public CurrentConditionsReport(IObservable<WeatherInfo> weatherInfoObservable) : base(weatherInfoObservable)
        {
        }

        public override void UpdateReport(WeatherInfo weatherInfo)
        {
            if (weatherInfo is null)
            {
                throw new ArgumentNullException();
            }

            this.ReportInfo = weatherInfo.GetWeatherInfo();
        }

        public override string MakeReport()
        {
            return
                $"{DateTime.Now.ToString("f", CultureInfo.CurrentCulture)}\nTemperature is {ReportInfo.Temperature}\nHumidity is {ReportInfo.Humidity}\nPressure is {ReportInfo.Pressure}";
        }
    }
}