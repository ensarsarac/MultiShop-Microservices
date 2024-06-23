using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string token = "";
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:5001/connect/token"),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"client_id","MultiShopVisitorId" },
                    {"client_secret","multishopsecret" },
                    {"grant_type","client_credentials" },
                })
            };
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenResponse = JObject.Parse(content);
                token = tokenResponse["access_token"].ToString();
            }
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Abouts");
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<ResultAboutDto>>(readData);
            return View(jsonData);
        }
    }
}
