using HB.WebAPITokenIdentiyBook.Dtos;
using HB.WebAPITokenIdentiyBook.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HB.WebAPITokenIdentiyBook.Controllers
{
	
	[Route("api/[Controller]")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Login()
		{

			return View();
		}
		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			var user = await _userManager.FindByNameAsync(loginDto.Username);
			if (user != null)
			{
				var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
				if (result.IsLockedOut)
				{
					ViewBag.ErrorMessage=user.LockoutEnd.ToString();
					return View();
				}
				if (!result.Succeeded)
				{
					await _userManager.AccessFailedAsync(user);
					var count=await _userManager.GetAccessFailedCountAsync(user);
					ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı," +count+ " kere hatalı giriş yaptın.";
					return View();
				}
			}
			ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı";
			return View();
		}
		
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost("Register")]
		public async Task<IActionResult> Register(RegisterDto registerDto)
		{
			return View();
		}

		
		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return Redirect("/");
		}
	}
	
}
