using CMS.Application.Abstraction.Services;
using CMS.Application.Abstraction.Services.DTOs;
using CMS.Application.Behaviors;
using CMS.Application.Behaviors.DTOs;
using CMS.Application.Services.Exceptions;
using CMS.Domain.Entities;
using CMS.Domain.Repository;
using CMS.Domain.ValueObjects;
using Microsoft.Extensions.Options;

namespace CMS.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJWTTokenProvider _jwtTokenService;
        private readonly IClaimProvider _claimProvider;


        public AuthenticationService(IUserRepository userAccountRepository,
                                     IPasswordHasher passwordHasher,
                                     IJWTTokenProvider jwtTokenService,
                                     IClaimProvider claimProvider,
                                     IOptions<JwtOptions> options)
        {
            _userRepository = userAccountRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
            _jwtOptions = options;
            _claimProvider = claimProvider;
        }

        public Task<string> GetRefreshToken(TokenRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetTokenAsync(TokenRequestDto user)
        {
            var theUser = await _userRepository.GetUserAsync(user.Username);

            if (theUser is null)
            {
                throw new UserNotFoundException();
            }

            var verificationResult = _passwordHasher.VerifyHashedPassword(theUser.Password, user.Password);

            if (verificationResult == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedUserException();
            }

            if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
            {
                theUser.UpdatePassword(_passwordHasher.HashPassword(user.Password));

                _userRepository.Update(theUser);

                await _userRepository.SaveChangesAsync();
            }

            var claims = _claimProvider.GetClaims();

            var token = _jwtTokenService.GenerateToken(
                _jwtOptions.Value.Key,
                _jwtOptions.Value.Issuer,
                _jwtOptions.Value.Audience,
                claims);

            return token;
        }

        public async Task<RegisterResult> RegisterAsync(RegisterRequestDto dto)
        {
            var theUser = await _userRepository.GetUserAsync(dto.Username);

            if (theUser is not null)
            {
                throw new UserNameExistenceException();
            }

            var password = _passwordHasher.HashPassword(dto.Password);

            var newUser = User.Create(UserId.Empty, Email.Empty, dto.Username, password, UserStatus.Active);

            await _userRepository.AddAsync(newUser);

            await _userRepository.SaveChangesAsync();

            return new RegisterResult
            {
                Id = newUser.UserId.Value,
                Username = newUser.Username,
                Password = newUser.Password,
                Status = newUser.Status,

            };
        }


    }
}
