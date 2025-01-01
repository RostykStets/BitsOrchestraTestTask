using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }

        public UserInfoDto()
        {
            Id = 0;
            Name = "";
            DateOfBirth = new DateOnly();
            Married = false;
            Phone = "";
            Salary = 0;
        }

        public UserInfoDto(UserInfo userInfo)
        {
            Id = userInfo.Id;
            Name = userInfo.Name;
            DateOfBirth = userInfo.DateOfBirth;
            Married = userInfo.Married;
            Phone = userInfo.Phone;
            Salary = userInfo.Salary;
        }

        public UserInfo toEntity()
        {
            UserInfo userInfo = new UserInfo()
            {
                Id = this.Id,
                Name = this.Name,
                DateOfBirth = this.DateOfBirth,
                Married = this.Married,
                Phone = this.Phone,
                Salary = this.Salary
            };
            return userInfo;
        }
    }
}
