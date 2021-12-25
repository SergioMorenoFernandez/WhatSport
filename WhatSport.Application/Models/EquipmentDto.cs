using WhatSport.Domain.Models;

namespace WhatSport.Application.Models
{
    public class EquipmentDto
    {
        public EquipmentDto(Equipment value)
        {
            Id = value.Id;
            Description = value.Description;
            UserId = value.Player?.User?.Id;
            UserName = value.Player?.User?.Name;
        }

        public int Id { get; }
        public string Description { get; }

        public int? UserId { get; }
        public string? UserName { get; }
    }
}
