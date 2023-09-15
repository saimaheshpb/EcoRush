using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proj_Ecorush.Models;

public partial class EcoRushDbContext : DbContext
{
    public EcoRushDbContext()
    {
    }

    public EcoRushDbContext(DbContextOptions<EcoRushDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Afforestation> Afforestations { get; set; }

    public virtual DbSet<Carpooling> Carpoolings { get; set; }

    public virtual DbSet<EvTravel> EvTravels { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    public virtual DbSet<WalkCycle> WalkCycles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Afforestation>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("afforestation_pkey");

            entity.ToTable("afforestation");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.ActivityDate).HasColumnName("activity_date");
            entity.Property(e => e.Ccawarded).HasColumnName("ccawarded");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("email_id");
            entity.Property(e => e.Evidence).HasColumnName("evidence");
            entity.Property(e => e.PlantaionLoc)
                .HasMaxLength(50)
                .HasColumnName("plantaion_loc");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Email).WithMany(p => p.Afforestations)
                .HasForeignKey(d => d.EmailId)
                .HasConstraintName("fk_afforestation");
        });

        modelBuilder.Entity<Carpooling>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("carpooling_pkey");

            entity.ToTable("carpooling");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.ActivityDate).HasColumnName("activity_date");
            entity.Property(e => e.Ccawarded).HasColumnName("ccawarded");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("email_id");
            entity.Property(e => e.EndLoc)
                .HasMaxLength(50)
                .HasColumnName("end_loc");
            entity.Property(e => e.Evidence).HasColumnName("evidence");
            entity.Property(e => e.StartLoc)
                .HasMaxLength(50)
                .HasColumnName("start_loc");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Email).WithMany(p => p.Carpoolings)
                .HasForeignKey(d => d.EmailId)
                .HasConstraintName("fk_carpool");
        });

        modelBuilder.Entity<EvTravel>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("ev_travel_pkey");

            entity.ToTable("ev_travel");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.ActivityDate).HasColumnName("activity_date");
            entity.Property(e => e.Ccawarded).HasColumnName("ccawarded");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("email_id");
            entity.Property(e => e.EndLoc)
                .HasMaxLength(50)
                .HasColumnName("end_loc");
            entity.Property(e => e.Evidence).HasColumnName("evidence");
            entity.Property(e => e.StartLoc)
                .HasMaxLength(50)
                .HasColumnName("start_loc");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Email).WithMany(p => p.EvTravels)
                .HasForeignKey(d => d.EmailId)
                .HasConstraintName("fk_carpool");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("userinfo_pkey");

            entity.ToTable("userinfo");

            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("email_id");
            entity.Property(e => e.CcPoints).HasColumnName("ccpoints");
            entity.Property(e => e.OfficeLocation)
                .HasMaxLength(50)
                .HasColumnName("officelocation");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.URole)
                .HasMaxLength(50)
                .HasColumnName("urole");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<WalkCycle>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("walk_cycle_pkey");

            entity.ToTable("walk_cycle");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.ActivityDate).HasColumnName("activity_date");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(50)
                .HasColumnName("activity_type");
            entity.Property(e => e.Ccawarded).HasColumnName("ccawarded");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("email_id");
            entity.Property(e => e.Evidence).HasColumnName("evidence");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Email).WithMany(p => p.WalkCycles)
                .HasForeignKey(d => d.EmailId)
                .HasConstraintName("fk_walkcycle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
