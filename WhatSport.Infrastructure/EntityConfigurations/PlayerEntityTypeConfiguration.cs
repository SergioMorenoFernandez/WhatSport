using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.EntityConfigurations
{
    internal class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Note).IsRequired();
            builder.HasOne(p => p.Match).WithMany(m => m.Players).HasForeignKey(p => p.MatchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.User).WithMany(u => u.Players).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
