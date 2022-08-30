using ChatApp.Application.DTOs;
using ChatApp.Application.services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsysc([FromBody] RegisterAppViewDTOs model)
        {
            if (ModelState.IsValid)
            {
                var reults = await _authService.RegisterUserAsync(model);
                if (reults.IsSuccess)
                    return Ok(reults);//Status Code : 200

                return BadRequest(reults);

            }

            return BadRequest("Some Properties are not Valid ");//status code : 400
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsysc([FromBody] LoginAppDTOs model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginUserAsync(model);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some Properties Are Not Valid");
        }

    }
}
