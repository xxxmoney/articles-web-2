﻿using Microsoft.EntityFrameworkCore;
using Web.Data.Models;

namespace Web.Data.Contexts
{
    public class WebContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(nameof(User), "dbo");

                entity.HasIndex(e => e.Email)
                    .HasDatabaseName("IX_User_Email")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength(true);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable(nameof(Article), "dbo");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PictureName)
                    .IsRequired(false)
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.UpdatedAt)
                    .IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Article_User");
            });
        }

    }
}
