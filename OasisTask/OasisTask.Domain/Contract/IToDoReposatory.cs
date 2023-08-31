using OasisTask.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.Contract
{
    public interface IToDoReposatory : IReposatory<ToDo,int>
    {
        public Task<IEnumerable<ToDo>> InsertRangeAsync(IEnumerable<ToDo> toDoList);
    }
}
