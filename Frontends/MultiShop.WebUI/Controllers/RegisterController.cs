using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
		{
			if(createRegisterDto.Password == createRegisterDto.ConfirmPassword)
			{
				var client = _httpClientFactory.CreateClient();
				var values = JsonConvert.SerializeObject(createRegisterDto);
				var content = new StringContent(values, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("http://localhost:5001/api/Register",content);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index","Login");
				}
			}
			
			return View(createRegisterDto);
		}
	}
}
