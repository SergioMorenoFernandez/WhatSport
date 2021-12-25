using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Equipments
{
    public class EquipmentQuery : IRequest<EquipmentDto[]>
    {
        public EquipmentQuery(int matchId)
        {
            MatchId = matchId;
        }


        public int MatchId { get; }
    }
}
