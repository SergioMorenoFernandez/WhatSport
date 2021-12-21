using MediatR;

namespace WhatSport.Application.Commands.Scores
{
    public class EquipmentCommand : IRequest<bool>
    {
        public EquipmentCommand(int matchId, string name)
        {
            this.MatchId = matchId;
            this.Name = name;
        }

        public string Name { get; }

        public int MatchId { get; }


    }
}
