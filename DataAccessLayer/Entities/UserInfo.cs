﻿namespace DataAccessLayer.Entities
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone {  get; set; }
        public decimal Salary { get; set; }

    }
}
