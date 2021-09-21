using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestProject.Models
{
    public partial class RegistrationDynamicContext : DbContext
    {
        public RegistrationDynamicContext()
        {
        }

        public RegistrationDynamicContext(DbContextOptions<RegistrationDynamicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogginAnotherCountry> LogginAnotherCountry { get; set; }
        public virtual DbSet<RegistartionByDevice> RegistartionByDevice { get; set; }
        public virtual DbSet<RegistrationByMonth> RegistrationByMonth { get; set; }
        public virtual DbSet<SessionDuration> SessionDuration { get; set; }
        public virtual DbSet<SessionsByHour> SessionsByHour { get; set; }
        public virtual DbSet<SessionsMoreOneDevice> SessionsMoreOneDevice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogginAnotherCountry>(entity =>
            {
                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LoginTs)
                    .HasColumnName("LoginTS")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RegistartionByDevice>(entity =>
            {
                entity.Property(e => e.Device)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RegistrationByMonth>(entity =>
            {
                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SessionDuration>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<SessionsByHour>(entity =>
            {
                entity.Property(e => e.Hour).HasColumnType("datetime");
            });

            modelBuilder.Entity<SessionsMoreOneDevice>(entity =>
            {
                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LoginTs)
                    .HasColumnName("LoginTS")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
