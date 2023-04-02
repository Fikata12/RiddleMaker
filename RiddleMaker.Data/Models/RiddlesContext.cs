using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RiddleMaker.Data.Models
{
    public partial class RiddlesContext : DbContext
    {
        public RiddlesContext()
        {
        }

        public RiddlesContext(DbContextOptions<RiddlesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Riddle> Riddles { get; set; } = null!;
        public virtual DbSet<View01> View01s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Riddles;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Riddle>(entity =>
            {
                entity.Property(e => e.Answer).HasMaxLength(50);

                entity.Property(e => e.Riddle1)
                    .HasMaxLength(300)
                    .HasColumnName("Riddle");
            });

            modelBuilder.Entity<View01>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View01");

                entity.Property(e => e.Answer).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Riddle).HasMaxLength(300);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
