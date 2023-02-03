using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_jwt_authentication.Controllers
{
    [ApiController]
    [Route("{controler}")]
    public class MessageController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("/secretMessage")]
        public IActionResult SecretMessage() {
            return Ok("Super Secret Message!");
        }
    }
}
