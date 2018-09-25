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
            Weather weather = await Core.GetWeather("30519");//Buford, Ga
            getWeatherBtn.Text = weather.Title;
        } //Set the default page on app load 
    }
}