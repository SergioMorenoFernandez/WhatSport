using System.Collections.Generic;

namespace WhatSport.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public string Role { get; set; } = "User";

        public IEnumerable<Friend> ReceivedFriendRequests { get; set; } = new List<Friend>();
        public IEnumerable<Friend> SentFriendRequests { get; set; } = new List<Friend>();
        public IEnumerable<Level> Levels { get; set; } = new List<Level>();
        public IEnumerable<Player> Players { get; set; } = new List<Player>();
    }
}