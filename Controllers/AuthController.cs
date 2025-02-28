using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pos.Auth.Api.Service;
using Pos.Auth.Api.Models.Command;
using Pos.Auth.Api.Models.ViewModels;
using System.Net;

namespace Pos.Auth.Api.Controllers
{
    [Controller]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]//el controler quita el controller de la clase y deja la ruta con el nombre a usar
    public class AuthController : ControllerBase
    {
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUpAsync([FromBody] RegisterCommand registerCommand)
        {
            AuthService authService = new AuthService();
            AuthViewModel authViewModel=await authService.CreatedUserServiceAsync(registerCommand);
            return StatusCode(HttpStatusCode.Created.GetHashCode(),authViewModel);
        }

    }
}
