using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.EntityConfigurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Login).IsRequired();
            builder.HasIndex(u => u.Login).IsUnique();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
        }
    }
}
