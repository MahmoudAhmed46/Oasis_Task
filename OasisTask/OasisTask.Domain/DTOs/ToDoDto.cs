using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.DTOs
{
    public class ToDoDto
    {
        [Required(ErrorMessage ="User Id Required")]
        public int userId { get; set; }

        [Required(ErrorMessage = "Title Field Required")]

        public string title { get; set; }

        [Required(ErrorMessage = "ToDo Status Required")]

        public bool completed { get; set; }
    }
}
