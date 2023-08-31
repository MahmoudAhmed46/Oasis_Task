using AutoMapper;
using OasisTask.BL.Contract;
using OasisTask.BL.DTOs;
using OasisTask.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IQueryable<updateToDoDto>> GetToDoPagination(int pageIndex = 1, int pageSize = 10)
        {
            var TodoList = await _unitOfWork.ToDos.GetAllAsync();
            var paginateToDoList = TodoList.Skip(pageSize*(pageIndex-1)).Take(pageSize)
                                           .Select(t=>_mapper.Map<updateToDoDto>(t));
            return paginateToDoList;
        }
    }
}
