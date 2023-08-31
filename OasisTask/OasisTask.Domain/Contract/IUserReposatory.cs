using OasisTask.BL.DTOs;
using OasisTask.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.Contract
{
    public interface IUserReposatory : IReposatory<ApplicationUser,string>
    {
        public Task<TokenDto> CheckLogin(LoginUserDto userDto);
    }
}
