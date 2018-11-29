using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymAppCore.Models.Authentication;
using GymAppData.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GymAppCore.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            AuthenticationDbContext appDbContext,
            IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Post([FromBody]LoginModel credentials)
        {
            if (string.IsNullOrEmpty(credentials.Email) || string.IsNullOrEmpty(credentials.Password))
            {
                return new OkObjectResult(new LoginResult
                {
                    Succeeded = false,
                    Errors = new List<LoginError>
                    {
                        new LoginError
                        {
                            Code = "BADINFO",
                            Description = "Email or password missing."
                        }
                    }
                });
            }

            var userToVerify = await _userManager.FindByNameAsync(credentials.Email);

            if (userToVerify == null)
            {
                return new OkObjectResult(new LoginResult
                {
                    Succeeded = false,
                    Errors = new List<LoginError>
                    {
                        new LoginError
                        {
                            Code = "NOTFND",
                            Description = "Email does not exist."
                        }
                    }
                });
            }

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, credentials.Password))
            {
                var token = await GenerateToken(credentials.Email, userToVerify.Id);
                return new OkObjectResult(new LoginResult
                {
                    Succeeded = true,
                    Token = token
                });
            }

            return new OkObjectResult(new LoginResult
            {
                Succeeded = false,
                Errors = new List<LoginError>
                    {
                        new LoginError
                        {
                            Code = "BADPAS",
                            Description = "Password is incorrect."
                        }
                    }
            });
        }

        // POST api/accounts
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]RegisterUserModel model)
        {
            var userIdentity = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            if (result.Errors.Any())
            {
                return new OkObjectResult(result);
            }

            _appDbContext.SaveChanges();

            var token = GenerateToken(model.Email, userIdentity.Id);

            return new OkObjectResult(new { succeeded = true, authToken = token });
        }

        private async Task<Token> GenerateToken(string email, string userId)
        {
            var claimIdentity = _jwtFactory.GenerateClaimsIdentity(email, userId);
            var jwt = await TokenGenerator.GenerateJwt(claimIdentity, _jwtFactory, email, _jwtOptions);
            return jwt;
        }
    }
}