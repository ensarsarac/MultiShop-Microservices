using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApi.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApi.Controllers
{
    public class DefaultController : Controller
    {

        public async Task<IActionResult> WeatherDetail()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/kocaeli"),
                Headers =
    {
        { "x-rapidapi-key", "a506d0b55amshcfb29f2e4989817p174e30jsn4ef35ad88098" },
        { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                ViewBag.temp = result.data.temp;
				

			}

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&language=en&to_symbol=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "a506d0b55amshcfb29f2e4989817p174e30jsn4ef35ad88098" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                var result2 = JsonConvert.DeserializeObject<ExchangeViewModel>(body2);
                ViewBag.exchange = result2.data.exchange_rate;
            }



            return View();
		}
        public async Task<IActionResult> Exchange()
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&language=en&to_symbol=TRY"),
				Headers =
	{
		{ "x-rapidapi-key", "a506d0b55amshcfb29f2e4989817p174e30jsn4ef35ad88098" },
		{ "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                ViewBag.exchange = result.data.exchange_rate;
			}
            return View();
		}

        public async Task<IActionResult> ProductList()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search?q=Logitech%20mouse&country=us&language=en&page=1&limit=30&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"),
                Headers =
    {
        { "x-rapidapi-key", "a506d0b55amshcfb29f2e4989817p174e30jsn4ef35ad88098" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductViewModel>(body);
                return View(result);
            }
        }
    }
}
