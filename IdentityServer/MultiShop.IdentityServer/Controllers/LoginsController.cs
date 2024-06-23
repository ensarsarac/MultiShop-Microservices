using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpPost]
		public async Task<IActionResult> LoginUser(UserLoginDto userLoginDto)
		{
			var result =await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password,false,false);
            if (result.Succeeded)
            {
				var currentUser = await _userManager.FindByNameAsync(userLoginDto.Username);
				var model = new GetChectAppUserViewModel();
				if(currentUser == null)
				{
					model.IsExist = false;
				}
				else
				{
                    model.Username = userLoginDto.Username;
                    model.Id = currentUser.Id;
					model.IsExist=true;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
				
				return Ok();
			}
			else
			{
				return Ok("Kullanıcı adı veya şifre hatalı!");
			}
		}
	}
}
