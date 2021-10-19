using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Rockstar.Models
{
    public partial class RockStarDbContext : DbContext
    {
        public RockStarDbContext()
        {
        }

        public RockStarDbContext(DbContextOptions<RockStarDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Source> Source { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.Url);

                entity.Property(e => e.Url).HasMaxLength(200);

                entity.Property(e => e.Author).HasMaxLength(30);

                entity.Property(e => e.PublishedAt).HasColumnType("datetime");

                entity.Property(e => e.Source).HasMaxLength(20);
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Category).HasMaxLength(20);

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.Language).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Url).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
