﻿using Microsoft.EntityFrameworkCore;
using Musical.Entity.Models;

namespace Musical.Data.Data
{
    public partial class MusicalogContext : DbContext
    {
        public MusicalogContext()
        {
        }

        public MusicalogContext(DbContextOptions<MusicalogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Label).HasMaxLength(255);

                entity.Property(e => e.Stock).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
