using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace prjCramSchoolSystem.Models
{
    public partial class CramSchoolDBContext : DbContext
    {
        public CramSchoolDBContext()
        {
        }

        public CramSchoolDBContext(DbContextOptions<CramSchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TStudentProfile> TStudentProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CramSchoolDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<TStudentProfile>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tStudentProfile");

                entity.Property(e => e.FId).HasColumnName("fID");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(10)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FAddress)
                    .HasMaxLength(50)
                    .HasColumnName("fAddress");

                entity.Property(e => e.FBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fBirthDate");

                entity.Property(e => e.FCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreateDate");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FEnrollment)
                    .HasMaxLength(50)
                    .HasColumnName("fEnrollment");

                entity.Property(e => e.FGender)
                    .HasMaxLength(50)
                    .HasColumnName("fGender");

                entity.Property(e => e.FGrade)
                    .HasMaxLength(50)
                    .HasColumnName("fGrade");

                entity.Property(e => e.FName)
                    .HasMaxLength(20)
                    .HasColumnName("fName");

                entity.Property(e => e.FParentName)
                    .HasMaxLength(50)
                    .HasColumnName("fParentName");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(50)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FPhone)
                    .HasMaxLength(50)
                    .HasColumnName("fPhone");

                entity.Property(e => e.FStatus)
                    .HasMaxLength(50)
                    .HasColumnName("fStatus");

                entity.Property(e => e.FThumbnailUrl)
                    .HasMaxLength(50)
                    .HasColumnName("fThumbnailUrl");

                entity.Property(e => e.FUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fUpdateDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
