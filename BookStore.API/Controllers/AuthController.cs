using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public AuthController(ILogger<AuthController> logger, IMapper mapper, UserManager<ApiUser> userManager)
        {
            _logger = logger;
            this._mapper = mapper;
            this._userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserDto userDto) 
        {
            _logger.LogInformation($"Registration Attempt for {userDto.Email}");
            try
            {
                var user = _mapper.Map<ApiUser>(userDto);
                user.UserName = userDto.Email;
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                await _userManager.AddToRoleAsync(user, "User");

                return Accepted();
            } catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            _logger.LogInformation($"Login Attempt for {loginUserDto.Email}");
            try
            {
                var user = await _userManager.FindByEmailAsync(loginUserDto.Email);
                var passswordValid = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);
                if (!passswordValid)
                {
                    return NotFound();
                }

                return Accepted();
                

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        }
}
