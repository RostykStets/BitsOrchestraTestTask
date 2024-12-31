using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementations
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly AppDbContext _context;

        public UserInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteUserInfo(int userInfoId)
        {
            var userInfo = await _context.UsersInfos.FindAsync(userInfoId);
            if (userInfo != null)
            {
                _context.UsersInfos.Remove(userInfo);
            }
            await Save();
        }

        public async Task<IEnumerable<UserInfo>> GetUserInfos()
        {
            return await _context.UsersInfos.ToListAsync();
        }

        public async Task InsertUserInfo(UserInfo userInfo)
        {
            await _context.UsersInfos.AddAsync(userInfo);
            await Save();
        }

        public async Task UpdateUserInfo(UserInfo userInfo)
        {
            _context.Entry(userInfo).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
