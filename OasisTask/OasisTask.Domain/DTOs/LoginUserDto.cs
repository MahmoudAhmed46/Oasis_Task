using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.DTOs
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "UserName Field Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Field Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
