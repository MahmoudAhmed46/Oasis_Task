using Microsoft.EntityFrameworkCore;
using OasisTask.BL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.DAL.Reposatories
{
    public class Reposatory<T, Tid> : IReposatory<T, Tid> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _DbSet;
        public Reposatory(ApplicationDbContext context)
        {
            _context = context;
            _DbSet = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T item)
        {
            var result = (await _DbSet.AddAsync(item)).Entity;

            return result;
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            return (Task.FromResult(_DbSet.Select(item => item)));
        }

        public async Task<T> GetByIdAsync(Tid id)
        {
            return await _DbSet.FindAsync(id);
        }
        public async Task<bool> DeleteAsync(Tid id)
        {
            var item = await _DbSet.FindAsync(id);
            var result = _DbSet.Remove(item);
            return result != null ? true : false;
        }

        public Task<T> UpdateAsync(T item)
        {
            var result = _context.Update(item);
            return Task.FromResult(item);
        }
       
    }
}
