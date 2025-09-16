using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Traning.Models;

namespace Traning.Data;

public partial class TrainingContext : DbContext
{
    public TrainingContext()
    {
    }

    public TrainingContext(DbContextOptions<TrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Athlete> Athletes { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.200.13;database=traning_db;user=student;password=student", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Athlete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.SkillLevel).HasMaxLength(255);
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.AthleteId, "FK_Attendances_AthleteId");

            entity.HasIndex(e => e.TraningId, "FK_Attendances_TraningId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AthleteId).HasColumnType("int(11)");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Grade).HasColumnType("int(11)");
            entity.Property(e => e.TraningId).HasColumnType("int(11)");

            entity.HasOne(d => d.Athlete).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.AthleteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendances_AthleteId");

            entity.HasOne(d => d.Traning).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.TraningId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendances_TraningId");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.Duration).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
