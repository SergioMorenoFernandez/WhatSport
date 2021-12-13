using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.EntityConfigurations
{
    internal class ClubSportEntityTypeConfiguration : IEntityTypeConfiguration<ClubSport>
    {
        public void Configure(EntityTypeBuilder<ClubSport> builder)
        {
            builder.ToTable("ClubSports");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Club).WithMany(c => c.ClubSports).HasForeignKey(c => c.ClubId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Sport).WithMany(s => s.ClubSports).HasForeignKey(c => c.SportId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
