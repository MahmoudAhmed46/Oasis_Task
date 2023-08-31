using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.DTOs
{
    public class TokenDto
    {
        public string? userId { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
