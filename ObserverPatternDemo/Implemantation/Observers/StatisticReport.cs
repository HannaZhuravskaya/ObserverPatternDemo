using System;
using System.Globalization;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : Report
    {
        private int _numberOfReports;
        private DateTime _startOfStatistics;
        private DateTime _endOfStatistics;

        public StatisticReport()
        {
            this._numberOfReports = 0;
        }

        public StatisticReport(IObservable<WeatherInfo> weatherInfoObservable) : base(weatherInfoObservable)
        {
            this._numberOfReports = 0;
        }

        public override void UpdateReport(WeatherInfo weatherInfo)
        {
            if (weatherInfo is null)
            {
                throw new ArgumentNullException();
            }

            this.UpdateReportInfo(weatherInfo);
        }

        public override string MakeReport()
        {
            var a = (double)ReportInfo.Temperature / this._numberOfReports;
            return
                $"{_startOfStatistics.ToString("f", CultureInfo.CurrentCulture)} - {_endOfStatistics.ToString("f", CultureInfo.CurrentCulture)}\nTemperature is {(double)ReportInfo.Temperature / _numberOfReports}\nHumidity is {(double)ReportInfo.Humidity / _numberOfReports}\nPressure is {(double)ReportInfo.Pressure / _numberOfReports}";
        }

        private void UpdateReportInfo(WeatherInfo weatherInfo)
        {
            this._endOfStatistics = DateTime.Now;
            if (this._numberOfReports == 0)
            {
                this._startOfStatistics = this._endOfStatistics;
            }

            this.ReportInfo = new WeatherInfo()
            {
                Temperature = ReportInfo.Temperature + weatherInfo.Temperature,
                Humidity = ReportInfo.Humidity + weatherInfo.Humidity,
                Pressure = ReportInfo.Pressure + weatherInfo.Pressure
            };
            this._numberOfReports++;
        }
    }
}
