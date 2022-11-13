using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStore.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA0B5BE4A7")
                    .IsUnique();

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN")
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Year)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToAuthors");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "f006f943-8719-4f48-8a70-3326d230d5f1"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "ddf90a9c-e5b5-4c7d-a726-dcea74c31d02"
                }
            );

            var hahser = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id = "acbfad13-1932-4bbb-8f05-39bf06c6c784",
                    Email = "admin@bookstore.com",
                    NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                    UserName = "admin@bookstore.com",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hahser.HashPassword(null, "1nf1n1t0!")
                },
                new ApiUser
                {
                    Id = "93b72426-8409-4698-9326-ae0bf24576db",
                    Email = "user@bookstore.com",
                    NormalizedEmail = "USER@BOOKSTORE.COM",
                    UserName = "USERin@bookstore.com",
                    FirstName = "System",
                    LastName = "USER",
                    PasswordHash = hahser.HashPassword(null, "1nf1n1t0!")
                }
            );

            modelBuilder.Entity<IdentityUserRole<String>>().HasData(
                new IdentityUserRole<String>
                {
                    RoleId = "f006f943-8719-4f48-8a70-3326d230d5f1",
                    UserId = "93b72426-8409-4698-9326-ae0bf24576db"
                },
                new IdentityUserRole<String>
                {
                    RoleId = "ddf90a9c-e5b5-4c7d-a726-dcea74c31d02",
                    UserId = "acbfad13-1932-4bbb-8f05-39bf06c6c784"
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
