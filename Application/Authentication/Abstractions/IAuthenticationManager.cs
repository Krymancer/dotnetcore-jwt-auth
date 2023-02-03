using Application.Authentication.Common.Requests;
using Application.Authentication.Common.Responses;

namespace Application.Authentication.Abstractions
{
    public interface IAuthenticationManager
    {
        AuthorizationResponse Authenticate(AuthorizationRequest request);
    }
}
