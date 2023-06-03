﻿using LaptopShop.Models;
using LaptopShop.Models.ViewModels;

namespace LaptopShop.Repositories
{
	public interface IUserAuthenticationService
	{
		Task<Status> LoginAsync(LoginViewModel model);
		Task LogoutAsync();
		Task<Status> RegisterAsync(RegisterViewModel model);
		Task<Status> ChangePasswordAsync(ChangePasswordViewModel model, string username);
	}
}
