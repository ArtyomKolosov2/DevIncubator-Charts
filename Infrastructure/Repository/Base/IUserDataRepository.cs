using Core.Models;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Base
{
    public interface IUserDataRepository : IRepository<UserData>
    {
        Task<UserData> GetDuplicatedUserDataOrDefault(UserData duplicatedData);
        Task<IEnumerable<UserData>> GetAllUserData();
    }
}
