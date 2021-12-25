using MediatR;

namespace WhatSport.Application.Commands.Equipments
{
    public class EquipmentCommand : IRequest<bool>
    {
        public EquipmentCommand(string description)
        {
            this.Description = description;
        }

        public string Description { get; }

        public int MatchId { get; set; }


    }
}
