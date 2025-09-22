using CMS.Application.Abstraction.Services;
using CMS.Presentation.Controllers.DTOs.Requests.Controllers.DTOs.Requests;
using CMS.Presentation.Controllers.DTOs.Responses.Controllers.DTOs.Responses;
using CMS.Presentation.Controllers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.Presentation.Controllers
{
    [ApiController]
    [Route("[version]/[controller]")]
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
        public async Task<ActionResult<string>> LoginAsync([FromBody] LoginRequest request)
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
