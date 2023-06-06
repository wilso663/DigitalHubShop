using API.DTOs;
using API.Errors;
using Core.Interfaces;
using Core.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AccountController : BaseAPIController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if(user == null)
                return Unauthorized(new ApiErrorResponse(401));

            var results = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!results.Succeeded) 
                return Unauthorized(new ApiErrorResponse(401));

            return new UserDTO
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
            
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            var user = new AppUser
            {
                Email = registerDTO.Email,
                DisplayName = registerDTO.DisplayName,
                UserName = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded) return BadRequest(new ApiErrorResponse(400));

            return new UserDTO
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }
    }
}
