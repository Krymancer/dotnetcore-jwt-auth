using System.ComponentModel.DataAnnotations;

namespace Application.Authentication.Common.Requests
{
    public class AuthorizationRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
