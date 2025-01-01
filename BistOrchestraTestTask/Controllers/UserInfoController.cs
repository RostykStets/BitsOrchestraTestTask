using BistOrchestraTestTask.Models;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BistOrchestraTestTask.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IUserInfoService _userInfoService;
        private readonly List<UserInfo> _userInfoList;

        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
            _userInfoList = new List<UserInfo>();
        }
        public async Task<IActionResult> Index()
        {
            var userInfoDtoList = await _userInfoService.GetUserInfos();

            foreach (var userInfoDto in userInfoDtoList)
                _userInfoList.Add(new UserInfo(userInfoDto));

            return View(_userInfoList);
        }

        private UserInfo GetDataFromCSV(string line)
        {
            var data = line.Split(',');
            var userInfo = new UserInfo
            {
                Id = Convert.ToInt32(data[0]),
                Name = data[1].ToString(),
                DateOfBirth = DateOnly.Parse(data[2]),
                Married = Convert.ToBoolean(data[3]),
                Phone = data[4].ToString(),
                Salary = Convert.ToDecimal(data[5])
            };
            return userInfo;
        }
    }
}
