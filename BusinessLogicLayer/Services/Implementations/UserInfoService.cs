using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public async Task DeleteUserInfo(int userInfoId)
        {
            await _userInfoRepository.DeleteUserInfo(userInfoId);
        }

        public async Task<List<UserInfoDto>> GetUserInfos()
        {
            var userInfos = await _userInfoRepository.GetUserInfos();
            var userInfosDto = from userInfo in userInfos
                               select new UserInfoDto(userInfo);
            return userInfosDto.ToList();
        }

        public async Task InsertUserInfo(UserInfoDto userInfoDto)
        {
            await _userInfoRepository.InsertUserInfo(userInfoDto.toEntity());
        }

        public async Task UpdateUserInfo(UserInfoDto userInfoDto)
        {
            await _userInfoRepository.UpdateUserInfo(userInfoDto.toEntity());
        }
    }
}
