namespace WhatSport.Application.Models
{
    public class MatchDto
    {
        public MatchDto(Domain.Models.Match match)
        {
            Id = match.Id;
            DateStart = match.DateStart;
            TimeInMinutes = match.TimeInMinutes;
            OtherPlace = match.OtherPlace;
            Note = match.Note;
            SportId= match.SportId;
            ClubId= match.ClubId;
        }

        public int Id { get; set; }
        public DateTime? DateStart { get; set; }
        public int? TimeInMinutes { get; set; }
        public string OtherPlace { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public int? SportId { get; set; }
        public int? ClubId { get; set; }
    }
}
