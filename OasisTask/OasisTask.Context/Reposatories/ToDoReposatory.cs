using OasisTask.BL.Contract;
using OasisTask.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.DAL.Reposatories
{
    public class ToDoReposatory : Reposatory<ToDo, int>, IToDoReposatory
    {
        private readonly ApplicationDbContext _context;
        public ToDoReposatory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDo>> InsertRangeAsync(IEnumerable<ToDo> toDoList)
        {
           await _context.ToDo.AddRangeAsync(toDoList);
           return toDoList;
        }
    }
}
