using CMSApi.Abstraction.Services;
using CMSApi.Abstraction.Services.DTOs;
using CMSApi.Controllers.DTOs.Requests;
using CMSApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;



        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authorizationService)
        {
            _logger = logger;
            _authenticationService = authorizationService;
        }

        [HttpPost("/[action]")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var token = await _authenticationService.GetTokenAsync(request.ToDto());

            return Ok(token);
        }

        [HttpPost("/[action]")]
        public async Task<ActionResult<RegisterResponse>> RegisterAsync([FromBody] RegisterRequest request)
        {
            var registerResult = await _authenticationService.RegisterAsync(request.ToDto());

            return Ok(registerResult.ToResponse());
        }

    }
}
