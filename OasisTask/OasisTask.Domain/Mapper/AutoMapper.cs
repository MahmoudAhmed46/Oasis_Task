using AutoMapper;
using OasisTask.BL.DTOs;
using OasisTask.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ApplicationUser,RegisterUserDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginUserDto>().ReverseMap();
            CreateMap<ApplicationUser, GetUserDto>().ReverseMap();
            CreateMap<ToDo,ToDoDto>().ReverseMap();
            CreateMap<ToDo, updateToDoDto>().ReverseMap();
            CreateMap<ToDoDto, updateToDoDto>().ReverseMap();


        }
    }
}
