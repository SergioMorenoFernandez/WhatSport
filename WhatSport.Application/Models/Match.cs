namespace WhatSport.Application.Models
{
    public class Match
    {
        public Match(Domain.Models.Match match)
        {
            Id = match.Id;
            DateStart = match.DateStart;
            DateEnd= match.DateEnd;
            OtherPlace = match.OtherPlace;
            Note = match.Note;
            SportId= match.SportId;
            ClubId= match.ClubId;
        }

        public int Id { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; } 
        public string OtherPlace { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public int? SportId { get; set; }
        public int? ClubId { get; set; }
    }
}
