using MediatR;

namespace WhatSport.Application.Commands.Equipments
{
    public class AssignEquipmentCommand : IRequest<bool>
    {
        public AssignEquipmentCommand(int equipmentId, int userId, int matchId, bool assign)
        {
            EquipmentId = equipmentId;
            UserId = userId;
            MatchId = matchId;
            Assign = assign;
        }

        public int EquipmentId { get; }

        public int UserId { get; }

        public int MatchId { get; }

        public bool Assign { get; }


    }
}
