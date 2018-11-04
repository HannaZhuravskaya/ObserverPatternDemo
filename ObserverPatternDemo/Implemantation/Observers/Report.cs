using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public abstract class Report : IObserver<WeatherInfo>
    {
        private WeatherInfo _reportInfo;

        public Report()
        {
            ReportInfo = new WeatherInfo();
        }

        public Report(IObservable<WeatherInfo> weatherInfoObservable)
        {
            if (ReferenceEquals(weatherInfoObservable, null))
            {
                throw new ArgumentNullException();
            }

            weatherInfoObservable.Register(this);

            ReportInfo = new WeatherInfo();
        }

        public WeatherInfo ReportInfo
        {
            get
            {
                return new WeatherInfo()
                {
                    Temperature = _reportInfo.Temperature,
                    Humidity = _reportInfo.Humidity,
                    Pressure = _reportInfo.Pressure
                };
            }

            protected internal set
            {
                if (value is null)
                {
                    throw new ArgumentNullException();
                }

                _reportInfo = value;
            }
        }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (sender is null || info is null)
            {
                throw new ArgumentNullException();
            }

            UpdateReport(info);
        }

        public abstract void UpdateReport(WeatherInfo weatherInfo);

        public abstract string MakeReport();
    }
}