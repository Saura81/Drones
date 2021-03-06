﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Game_Of_Drones.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblMoves> TblMoves { get; set; }
        public virtual DbSet<TblRounds> TblRounds { get; set; }
        public virtual DbSet<TblScores> TblScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<TblMoves>(entity =>
            {
                entity.HasKey(e => e.MoveId)
                    .HasName("PK__tblMoves__A931A43C46C0AB23");

                entity.ToTable("tblMoves");

                entity.Property(e => e.MoveId).HasColumnName("MoveID");

                entity.Property(e => e.MoveName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRounds>(entity =>
            {
                entity.HasKey(e => e.RoundId)
                    .HasName("PK__tblRound__94D84E1A02D7BF82");

                entity.ToTable("tblRounds");

                entity.Property(e => e.RoundId).HasColumnName("RoundID");

                entity.Property(e => e.FirstPlayerMove)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstPlayerName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SecondPlayerMove)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SecondPlayerName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Winner)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblScores>(entity =>
            {
                entity.HasKey(e => e.ScoreId)
                    .HasName("PK__tblScore__7DD229F1E34C2843");

                entity.ToTable("tblScores");

                entity.Property(e => e.ScoreId).HasColumnName("ScoreID");

                entity.Property(e => e.PlayerName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });
        }
    }
}
