using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.EntityConfigurations
{
    internal class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipments");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Description).IsRequired();
            builder.HasOne(e => e.Match).WithMany(m => m.Equipments).HasForeignKey(e => e.MatchId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Player).WithMany(p => p.Equipments).HasForeignKey(e => e.PlayerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
