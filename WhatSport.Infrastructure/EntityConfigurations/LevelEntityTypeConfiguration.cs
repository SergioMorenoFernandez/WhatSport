using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.EntityConfigurations
{
    internal class LevelEntityTypeConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("Levels");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.HasOne(l => l.User).WithMany(u => u.Levels).HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(l => l.Sport).WithMany(s => s.Levels).HasForeignKey(l => l.SportId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
