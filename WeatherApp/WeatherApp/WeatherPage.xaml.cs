using System;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class WeatherPage : ContentPage
    {
        //TODO: Add app context on app start to display weather page
        public WeatherPage()
        {
            InitializeComponent();        
            BindingContext = new Weather();
        }

        //Added on click event for button to fetch zipcode weather
        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            //if zipCodeEntry is NOT empty, populate all data regarding weather from zipcode
            //using "Weather" identifier. Each requested value is located in Weather.cs
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                BindingContext = weather;
                getWeatherBtn.Text = "Search Again";
            }
        }
    }
}