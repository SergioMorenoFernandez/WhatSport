using MediatR;

namespace WhatSport.Application.Commands.Equipments
{
    public class DeleteEquipmentCommand : IRequest<bool>
    {
        public DeleteEquipmentCommand(int id, int matchId)
        {
            Id = id;
            Matchid = matchId;
        }

        public int Id { get; } 
        public int Matchid { get; }

    }
}
