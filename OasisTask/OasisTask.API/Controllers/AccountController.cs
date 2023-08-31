using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OasisTask.BL;
using OasisTask.BL.Contract;
using OasisTask.BL.DTOs;
using OasisTask.BL.Models;
using System.Text;

namespace OasisTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public AccountController(
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto userDto)
        {
            string msg = string.Empty;

            if (ModelState.IsValid)
            {
                var findByEmail = await _userManager.FindByEmailAsync(userDto.Email);
                var findByUserName = await _userManager.FindByNameAsync(userDto.UserName);

                if (findByEmail != null || findByUserName != null)
                {
                    return StatusCode(StatusCodes.Status403Forbidden,
                        new Response { Status="Error",Message="User Already Exist"});
                }
                var user = _mapper.Map<ApplicationUser>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if(result.Succeeded)
                {
                    return Ok(new Response { Status = "Success", Message = "User Created Successfully"});
                }
                else
                {
                    
                    foreach (var error in result.Errors)
                    {
                        msg += error.Description.ToString();
                    }
                   
                }
       
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                  new Response { Status = "Error", Message = msg });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto userDto)
        {
            string msg = string.Empty;

            if (ModelState.IsValid)
            {
                var user = _unitOfWork.Users.CheckLogin(userDto).Result;
                if (user.userId != null)
                {
                    return Ok(user);
                }
 
            }
            return StatusCode(StatusCodes.Status403Forbidden,
                       new Response { Status = "Error", Message = "Invalid UserName or Password" });
        }
    }
}
