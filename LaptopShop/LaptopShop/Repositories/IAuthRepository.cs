using LaptopShop.Models.Users;

namespace LaptopShop.Repositories
{
	public interface IAuthRepository
	{
		Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);
		Task<UserManagerResponse> LoginUserAsync(LoginModel model);
	}
}
