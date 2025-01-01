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

        [HttpPost]
        public async Task<IActionResult> UploadCSV(IFormFile csv)
        {
            if (csv != null && csv.Length > 0)
            {
                using (var reader = new StreamReader(csv.OpenReadStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        UserInfo newUserInfo = GetDataFromCSV(line);
                        await _userInfoService.InsertUserInfo(newUserInfo.ToDto());
                    }
                }
            }

            return RedirectToAction("Index", "UserInfo");
        }

        [HttpPost]
        public async Task<IActionResult> Save(int id, string name, DateOnly dateOfBirth, bool married, string phone, decimal salary)
        {
            var userInfoToUpdate = new UserInfo
            {
                Id = id,
                Name = name,
                DateOfBirth = dateOfBirth,
                Married = married,
                Phone = phone,
                Salary = salary
            }.ToDto();

            await _userInfoService.UpdateUserInfo(userInfoToUpdate);

            return RedirectToAction("Index", "UserInfo");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int userInfoId)
        {
            if (userInfoId > 0)
                await _userInfoService.DeleteUserInfo(userInfoId);

            return RedirectToAction("Index", "UserInfo");
        }

        private UserInfo GetDataFromCSV(string line)
        {
            var data = line.Split(',');
            var userInfo = new UserInfo
            {
                Name = data[0].ToString(),
                DateOfBirth = DateOnly.Parse(data[1]),
                Married = Convert.ToBoolean(data[2]),
                Phone = data[3].ToString(),
                Salary = Convert.ToDecimal(data[4])
            };
            return userInfo;
        }
    }
}
