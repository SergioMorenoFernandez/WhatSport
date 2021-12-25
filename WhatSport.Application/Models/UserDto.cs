namespace WhatSport.Application.Models
{
    public class UserDto
    {
        public UserDto(Domain.Models.User user)
        {
            Id = user.Id;
            Login = user.Login;
            Name = user.Name;
            LastName = user.LastName;
            Status = user.Status;
            Role = user.Role;
        }

        public int Id { get; }
        public string Login { get; }
        public string Name { get; }
        public string LastName { get; }
        public bool Status { get; }
        public string Role { get; }
    }
}
