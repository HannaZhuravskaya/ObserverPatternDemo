namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo
    {
        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public int Pressure { get; set; }

        public WeatherInfo GetWeatherInfo()
        {
            return new WeatherInfo()
            {
                Temperature = this.Temperature,
                Humidity = this.Humidity,
                Pressure = this.Pressure
            };
        }
    }
}