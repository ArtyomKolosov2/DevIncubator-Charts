using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetItemsList(); 
        Task<T> GetItem(int id); 
        Task CreateItem(T item); 
        Task UpdateItem(T item); 
        Task DeleteItem(T item); 
    }
}
