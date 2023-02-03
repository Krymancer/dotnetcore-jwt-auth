namespace Application.Services.Abstractions
{
    public interface IUserService
    {
        bool VerifyUser(string username, string password);
    }
}