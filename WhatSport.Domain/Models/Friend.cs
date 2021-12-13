namespace WhatSport.Domain.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int FriendUserId { get; set; }
        public User? FriendUser { get; set; }
    }
}
