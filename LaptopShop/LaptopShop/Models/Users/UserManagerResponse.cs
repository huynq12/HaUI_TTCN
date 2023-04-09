namespace LaptopShop.Models.Users
{
	public class UserManagerResponse
	{
		public bool IsSuccess { get; set; }
		public string Token { get; set; }
		public string Error { get; set; }
		public DateTime Expired { get; set; }
	}
}
