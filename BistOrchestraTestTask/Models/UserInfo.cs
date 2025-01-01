using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BistOrchestraTestTask.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }

        public UserInfo()
        {
            Id = 0;
            Name = "";
            DateOfBirth = new DateOnly();
            Married = false;
            Phone = "";
            Salary = 0;
        }

        public UserInfo(UserInfoDto userInfoDto)
        {
            Id = userInfoDto.Id;
            Name = userInfoDto.Name;
            DateOfBirth = userInfoDto.DateOfBirth;
            Married = userInfoDto.Married;
            Phone = userInfoDto.Phone;
            Salary = userInfoDto.Salary;
        }

        public UserInfoDto ToDto()
        {
            var userInfoDto = new UserInfoDto()
            {
                Id = this.Id,
                Name = this.Name,
                DateOfBirth = this.DateOfBirth,
                Married = this.Married,
                Phone = this.Phone,
                Salary = this.Salary
            };
            return userInfoDto;
        }
    }
}
