using OasisTask.DAL.Reposatories;
using OasisTask.DAL;
using OasisTask.BL.Contract;
using OasisTask.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserReposatory Users { get; private set; }

        public IToDoReposatory ToDos { get; private set; }

        public UnitOfWork(ApplicationDbContext context,IUserReposatory userReo, IToDoReposatory TodoRepo)
        {
            _context = context;
            Users = userReo;
            ToDos = TodoRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
