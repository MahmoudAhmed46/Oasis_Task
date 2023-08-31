using OasisTask.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.Services
{
    public interface IToDoService
    {
        public Task<IQueryable<updateToDoDto>> GetToDoPagination(int pageIndex, int pageSize);
    }
}
