using Application.Authentication.Abstractions;
using Application.Authentication.Common.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_jwt_authentication.Controllers
{
    [ApiController]
    [Route("{controler}")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;
        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [HttpPost]
        [Route("/auth")]
        [AllowAnonymous]
        public IActionResult Auth([FromBody] AuthorizationRequest request)
        {
            var token = _authenticationManager.Authenticate(request);
            return !string.IsNullOrEmpty(token.Token) ? Ok(token) : Unauthorized();
        }
    }
}
