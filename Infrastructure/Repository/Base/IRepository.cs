using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetItemsListAsync(); 
        Task<T> GetItemAsync(int id); 
        Task CreateItemAsync(T item); 
        Task UpdateItemAsync(T item); 
        Task DeleteItemAsync(T item); 
    }
}
