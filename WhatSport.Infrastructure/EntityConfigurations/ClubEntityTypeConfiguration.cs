using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.EntityConfigurations
{
    internal class ClubEntityTypeConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.ToTable("Clubs");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.PostalCode).IsRequired();
            builder.HasOne(c => c.City).WithMany(c => c.Clubs).HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
