using DatingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Data
{
    public class DatingAppContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DatingAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Login)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(e => e.CreateDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Like>()
               .Property(e => e.Status)
               .HasDefaultValueSql("0");

            modelBuilder.Entity<City>()
               .HasIndex(b => b.CityName)
               .IsUnique()
               .HasFilter(null);

            modelBuilder.Entity<Gender>()
               .HasIndex(g => g.GenderName)
               .IsUnique()
               .HasFilter(null);

            #region Like Many to Many

            // Configure the many-to-many relationship between UserProfile and Like
            modelBuilder.Entity<Like>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Sender)
                .WithMany(u => u.LikedUsers)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Receiver)
                .WithMany(u => u.LikedByUsers)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            // Additional configurations for UserProfile entity if needed
            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.LikedUsers)
                .WithOne(l => l.Sender)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.LikedByUsers)
                .WithOne(l => l.Receiver)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Message Many to Many
            // Configure the many-to-many relationship between UserProfile and Like
            modelBuilder.Entity<Message>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Message>()
                .HasOne(l => l.Sender)
                .WithMany(u => u.MessagedUsers)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            modelBuilder.Entity<Message>()
                .HasOne(l => l.Receiver)
                .WithMany(u => u.MessagedByUsers)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            // Additional configurations for UserProfile entity if needed
            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.MessagedUsers)
                .WithOne(l => l.Sender)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.MessagedByUsers)
                .WithOne(l => l.Receiver)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
