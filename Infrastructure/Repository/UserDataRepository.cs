using Core.Models;
using Core.ViewModels;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserDataRepository : Repository<UserData>, IUserDataRepository
    {
        public UserDataRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public Task<IEnumerable<UserData>> GetAllUserDataAsync() => GetItemsListAsync();


        public Task<UserData> GetDuplicatedUserDataOrDefaultAsync(UserData duplicatedData)
        {
            var userData = Context.UserDatas.FirstOrDefaultAsync
                (
                    userData =>
                    userData.A == duplicatedData.A &&
                    userData.B == duplicatedData.B &&
                    userData.C == duplicatedData.C &&
                    userData.RangeTo == duplicatedData.RangeTo &&
                    userData.RangeFrom == duplicatedData.RangeFrom
                );

            return userData;
        }
    }
}
