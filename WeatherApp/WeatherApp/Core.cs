using System;
using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            //OpenWeatherMap.org API key
            string key = "4401d342aaacd8f9a7ee91a2fb8e1c39";

            //url string param for query in DataService.
            //zipCode and key strings completing query url.
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + zipCode + ",us&appid=" + key + "&units=imperial";

            //Async Task using results to store resulting data from queryString for 
            //populating Weather.cs
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            //if Weather is not empty on execution, a new instance is created with
            //fresh weather data results with an updated zipCode
            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " F";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}