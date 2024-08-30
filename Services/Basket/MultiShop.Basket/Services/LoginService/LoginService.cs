namespace MultiShop.Basket.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httContextAccessor;
        public LoginService(IHttpContextAccessor httContextAccessor)
        {
            _httContextAccessor = httContextAccessor;
        }

        public string GetUserId => _httContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
