using LaptopShop.Data;
using LaptopShop.Models.Users;
using LaptopShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop.Controllers
{
	public class AuthController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		private readonly LaptopDbContext _context;
		private readonly IAuthRepository _authRepository;

		public AuthController(LaptopDbContext context, IAuthRepository userService)
		{
			_context = context;
			_authRepository = userService;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> RegisterUser(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _authRepository.RegisterUserAsync(model);
				if (result.IsSuccess)
				{
					return Ok(result);
				}
				return BadRequest();
			}
			return BadRequest();
		}

		[HttpPost("Login")]
		public async Task<IActionResult> LoginUser([FromBody] LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _authRepository.LoginUserAsync(model);
				if (result.IsSuccess)
				{
					return Ok(result);
				}
				return BadRequest();
			}
			return BadRequest();
		}
	}
}
