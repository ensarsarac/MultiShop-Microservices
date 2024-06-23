using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavbarComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutNavbarComponent(IHttpClientFactory httpClientFactory)
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
            var res = await client.GetAsync("https://localhost:7250/api/Categories");
            var read = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(read);
            return View(values);
        }
    }
}
