using MediatR;

namespace WhatSport.Application.Commands.Matches
{
    public  class CreateMatchCommand : IRequest<int>
    {
        public CreateMatchCommand(int sportId ,DateTime dateStart, int timeInMinutes)
       {
            DateStart = dateStart;
            TimeInMinutes = timeInMinutes;
            SportId = sportId;
        }
        public DateTime DateStart { get; set; }
        public int TimeInMinutes { get; set; }
        public string OtherPlace { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public int SportId { get; set; }
        public int? ClubId { get; set; }
    }
}
