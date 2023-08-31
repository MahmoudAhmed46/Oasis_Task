using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OasisTask.BL;
using OasisTask.BL.Contract;
using OasisTask.BL.DTOs;
using OasisTask.BL.Models;
using OasisTask.DAL.Reposatories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.DAL.Reposatories
{
    public class UserReposatory : Reposatory<ApplicationUser, string>, IUserReposatory
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserReposatory
            ( ApplicationDbContext context,
              UserManager<ApplicationUser> userManager,
              IConfiguration configuration,
              IMapper mapper) : base(context)
        {
                _userManager = userManager;
                _configuration = configuration;
                _mapper = mapper;
        }

        public async Task<TokenDto> CheckLogin(LoginUserDto userDto)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userDto.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, userDto.Password)) 
            {
                //create Token
                TokenDto token = CreateJwtToken(_mapper.Map<GetUserDto>(user));
                return token;
            }
            return new TokenDto
            {
                userId = null,
            };
        }
        private TokenDto CreateJwtToken(GetUserDto userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer= _configuration["JWT:ValidIssu"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userDto.Id),
                    new Claim(ClaimTypes.Name, userDto.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDto 
            { 
                userId=userDto.Id ,
                Token = tokenHandler.WriteToken(token), 
                Expiration = token.ValidTo 
            };
            
        }
    }
}
