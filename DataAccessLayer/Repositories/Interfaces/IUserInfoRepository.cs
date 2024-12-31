using DataAccessLayer.Entities;


namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserInfoRepository
    {
        Task<IEnumerable<UserInfo>> GetUserInfos();
        Task InsertUserInfo(UserInfo userInfo);
        Task UpdateUserInfo(UserInfo userInfo);
        Task DeleteUserInfo(int userInfoId);
        Task Save();
    }
}
