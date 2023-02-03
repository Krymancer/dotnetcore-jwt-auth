using Application.Authentication.Abstractions;
using Application.Authentication.Common.Requests;
using Application.Authentication.Common.Responses;
using Application.Configuration;
using Application.Services.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Authentication
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IUserService _userService;

        private const int TOKEN_DURATION_IN_MINUTES = 5;
        public AuthenticationManager(IOptions<JwtConfiguration> jwtConfiguration, IUserService userService) 
        { 
            _jwtConfiguration = jwtConfiguration.Value;
            _userService = userService;
        }
        

        public AuthorizationResponse Authenticate(AuthorizationRequest request)
        {
            if(_userService.VerifyUser(request.Username,request.Password))
            {
                var secret = Encoding.UTF8.GetBytes(_jwtConfiguration.Secret);
                var audience = _jwtConfiguration.Audience;
                var issuer = _jwtConfiguration.Issuer;
                var expires = DateTime.Now.AddMinutes(TOKEN_DURATION_IN_MINUTES);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, request.Username),
                    }),
                    Expires = expires,
                    Audience = audience,
                    Issuer = issuer,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha512Signature)
                    
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                var jwtToken = tokenHandler.WriteToken(token);

                return new AuthorizationResponse
                {
                    Token = jwtToken,
                };
            }

            return new AuthorizationResponse();
        }
    }
}
