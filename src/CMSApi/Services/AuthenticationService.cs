using CMSApi.Abstraction.Services;
using CMSApi.Abstraction.Services.DTOs;
using CMSApi.DTOs;
using CMSApi.Services.Exceptions;
using CMSRepository.Abstractions;
using CMSRepository.Models;
using Infrastructure.JWTProviders.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CMSApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJWTTokenProvider _jwtTokenService;


        public AuthenticationService(ILogger<AuthenticationService> logger,
                                     IUserRepository userAccountRepository,
                                     IPasswordHasher<User> passwordHasher,
                                     IJWTTokenProvider jwtTokenService,
                                     IOptions<JwtOptions> options)
        {
            _logger = logger;
            _userRepository = userAccountRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
            _jwtOptions = options;
        }

        public Task<string> GetRefreshToken(TokenDto dto)
        {
            throw new NotImplementedException(); 
        }

        public async Task<string> GetTokenAsync(TokenDto user)
        {
            var theUser = await _userRepository.GetUserAsync(user.Username);

            if (theUser is null)
            {
                throw new UserNotFoundException();
            }

            var verificationResult = _passwordHasher.VerifyHashedPassword(theUser, theUser.Password, user.Password);

            if (verificationResult == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedUserException();
            }

            if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
            {
                theUser.Password = _passwordHasher.HashPassword(theUser, user.Password);

                _userRepository.Update(theUser);

                await _userRepository.SaveChangesAsync();
            }

            var jwtTokenConfig = _jwtOptions.Value;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, theUser.Username),
                new Claim(JwtRegisteredClaimNames.NameId, theUser.Id.ToString()),
                new Claim(CustomizedUserClaimTypes.STATUS, theUser.Status.ToString()),
            };

            var token = _jwtTokenService.GenerateToken(
                jwtTokenConfig.Key,
                jwtTokenConfig.Issuer,
                jwtTokenConfig.Audience,
                claims);

            return token;
        }

        public async Task<RegisterResult> RegisterAsync(RegisterDto dto)
        {
            var theUser = await _userRepository.GetUserAsync(dto.Username);

            if (theUser is not null)
            {
                throw new UserNameExistenceException();
            }

            var newUser = new User()
            {
                Username = dto.Username,
            };

            newUser.Password = _passwordHasher.HashPassword(newUser, dto.Password);

            await _userRepository.AddAsync(newUser);

            await _userRepository.SaveChangesAsync();

            return new RegisterResult
            {
                Id = newUser.Id,
                Username = newUser.Username,
                Password = newUser.Password,
                Status = newUser.Status,

            };
        }


    }
}
