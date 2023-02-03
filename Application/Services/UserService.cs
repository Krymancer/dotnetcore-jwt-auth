using Application.Services.Abstractions;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public bool VerifyUser(string username, string password)
        {
            return SuperSecretAndSecureWayToVerifyAUser(username, password);
        }

        private bool SuperSecretAndSecureWayToVerifyAUser(string username, string password)
        {
            return username == "admin" && password == "admin";
        }
    }
}
