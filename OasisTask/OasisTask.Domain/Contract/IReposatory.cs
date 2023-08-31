using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OasisTask.BL.Contract
{
    public interface IReposatory<T,Tid> where T : class
    {
       public Task<T> CreateAsync(T item);
        public Task<T> GetByIdAsync(Tid id);
        public Task<IQueryable<T>> GetAllAsync();
        public Task<T> UpdateAsync(T item);
        public Task<bool> DeleteAsync(Tid id);
    }
}
