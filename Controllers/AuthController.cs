using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pos.Auth.Api.Models;
using System.Net;

namespace Pos.Auth.Api.Controllers
{
    [Controller]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]//el controler quita el controller de la clase y deja la ruta con el nombre a usar
      public class AuthController : ControllerBase
    {
        [HttpPost("sign-up")]
        public IActionResult SignUp([FromBody] RegisterCommand registerCommand)
        {
           
             return StatusCode(HttpStatusCode.Created.GetHashCode(),registerCommand);
        }

    }
}
