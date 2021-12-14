using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.EntityConfigurations
{
    internal class MatchEntityTypeConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Matches");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.OtherPlace);
            builder.Property(m => m.Note);
            builder.HasOne(m => m.Sport).WithMany(s => s.Matches).HasForeignKey(m => m.SportId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.Club).WithMany(c => c.Matches).HasForeignKey(m => m.ClubId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.City);
        }
    }
}
