using MediatR;

namespace WhatSport.Application.Commands.Matches
{
    public  class CreateMatchCommand : IRequest<bool>
    {
        public CreateMatchCommand(int sportId ,DateTime dateStart, DateTime dateEnd)
       {
            DateStart = dateStart;
            DateEnd = dateEnd;
            SportId = sportId;
        }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string OtherPlace { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public int SportId { get; set; }
        public int? ClubId { get; set; }
    }
}
