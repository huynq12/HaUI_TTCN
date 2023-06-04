using LaptopShop.Models.EF;
using LaptopShop.Models.ViewModels;
using LaptopShop.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop.Areas.Identity
{
	[Area("Identity")]
	public class UserAuthentication : Controller
	{
		private readonly IUserAuthenticationService _authService;
		private readonly NavigationManager _navigationManager;

		public UserAuthentication(IUserAuthenticationService authService,NavigationManager navigation)
		{
			this._authService = authService;
			_navigationManager = navigation;
		}


		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);
			var result = await _authService.LoginAsync(model);
			if (result.StatusCode == 1)
			{
				return RedirectToAction("Index","Home",new {area = "Customer"}	);
			}
			else
			{
				TempData["msg"] = result.Message;
				return RedirectToAction(nameof(Login));
			}
		}

		public IActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Registration(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
				 return View(model); 
			model.Role = "user";
			var result = await this._authService.RegisterAsync(model);
			TempData["msg"] = result.Message;
			return RedirectToAction(nameof(Login));
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await this._authService.LogoutAsync();
			return RedirectToAction(nameof(Login));
		}
		//[AllowAnonymous]
		//public async Task<IActionResult> RegisterAdmin()
		//{
		//    RegistrationModel model = new RegistrationModel
		//    {
		//        Username="admin",
		//        Email="admin@gmail.com",
		//        FirstName="John",
		//        LastName="Doe",
		//        Password="Admin@12345#"
		//    };
		//    model.Role = "admin";
		//    var result = await this._authService.RegisterAsync(model);
		//    return Ok(result);
		//}

		[Authorize]
		public IActionResult ChangePassword()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);
			var result = await _authService.ChangePasswordAsync(model, User.Identity.Name);
			TempData["msg"] = result.Message;
			return RedirectToAction("Index", "Home", new { area = "Customer" });
		}
	}
}
