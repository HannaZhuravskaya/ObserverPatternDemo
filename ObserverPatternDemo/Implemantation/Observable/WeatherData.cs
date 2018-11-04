using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> weatherInfoObservers;

        public WeatherData()
        {
            weatherInfoObservers = new List<IObserver<WeatherInfo>>();
        }
        
        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (sender is null || info is null)
            {
                throw new ArgumentNullException();
            }

            foreach (var weatherInfoObserver in weatherInfoObservers)
            {
                weatherInfoObserver.Update(sender, info);
            }
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            if (observer is null)
            {
                throw new ArgumentNullException();
            }

            if (!weatherInfoObservers.Contains(observer))
            {
                weatherInfoObservers.Add(observer);
            }
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (observer is null)
            {
                throw new ArgumentNullException();
            }
    
            weatherInfoObservers.Remove(observer);
        }

        public void UpdateWeatherInfo(WeatherInfo weatherInfo)
        {
            Notify(this, weatherInfo);
        }
    }
}