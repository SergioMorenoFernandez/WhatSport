using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.EntityConfigurations
{
    internal class ScoreConfirmationEntityTypeConfiguration : IEntityTypeConfiguration<ScoreConfirmation>
    {
        public void Configure(EntityTypeBuilder<ScoreConfirmation> builder)
        {
            builder.ToTable("ScoreConfirmations");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.HasOne(s => s.Player).WithMany(p => p.ScoreConfirmations).HasForeignKey(s => s.PlayerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Score).WithMany(s => s.ScoreConfirmations).HasForeignKey(s => s.ScoreId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
