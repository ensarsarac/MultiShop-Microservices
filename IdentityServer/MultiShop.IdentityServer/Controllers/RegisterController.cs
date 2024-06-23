using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public RegisterController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpPost]
		public async Task<IActionResult> RegisterUser(UserRegisterDto model)
		{
			var values = new ApplicationUser()
			{
				UserName = model.Username,
				Email = model.Email,
				Name = model.Name,
				Surname = model.Surname,
			};
			var result = await _userManager.CreateAsync(values,model.Password);
			if (result.Succeeded)
			{
				return Ok("Kullanıcı başarıyla kayıt edildi.");
			}
			else
			{
				return Ok("Bir hata oluştu. Tekrar deneyiniz..");
			}
		}
	}
}
