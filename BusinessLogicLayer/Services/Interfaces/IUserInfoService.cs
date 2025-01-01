using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<List<UserInfoDto>> GetUserInfos();
        Task InsertUserInfo(UserInfoDto userInfoDto);
        Task UpdateUserInfo(UserInfoDto userInfoDto);
        Task DeleteUserInfo(int userInfoId);
    }
}
