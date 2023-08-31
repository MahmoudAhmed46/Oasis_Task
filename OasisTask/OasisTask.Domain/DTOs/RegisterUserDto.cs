using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.DTOs
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage ="UserName Field Required")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage ="Email Address Field Required")]
        [RegularExpression(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Field Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
