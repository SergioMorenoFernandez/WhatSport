using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.EntityConfigurations
{
    internal class FriendEntityTypeConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("Friends");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasOne(f => f.User).WithMany(u => u.SentFriendRequests).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.FriendUser).WithMany(u => u.ReceivedFriendRequests).HasForeignKey(f => f.FriendUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
