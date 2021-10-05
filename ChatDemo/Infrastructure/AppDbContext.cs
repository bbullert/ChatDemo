using ChatDemo.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<FriendRequest> FriendRequests { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(user =>
            {
                user.Ignore(x => x.Friends);
            });

            modelBuilder.Entity<FriendRequest>(friendRequest =>
            {
                friendRequest.HasKey(x => new { x.SenderId, x.ReceiverId });

                friendRequest.HasOne(x => x.Sender)
                    .WithMany(x => x.SentFriendRequests)
                    .HasForeignKey(x => x.SenderId);

                friendRequest.HasOne(x => x.Receiver)
                    .WithMany(x => x.ReceivedFriendRequests)
                    .HasForeignKey(x => x.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
