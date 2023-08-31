using Microsoft.EntityFrameworkCore;
using OasisTask.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        //IReposatory<ApplicationUser,string> Users { get; }
        IUserReposatory Users { get; }  
        IToDoReposatory ToDos { get; }
        public Task<int> SaveChangesAsync();
    }
}
