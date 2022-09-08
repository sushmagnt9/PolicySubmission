using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PolicySubmission.DatabaseEntity
{
    public partial class PolicySubmissionContext : DbContext
    {
        public PolicySubmissionContext()
        {
        }

        public PolicySubmissionContext(DbContextOptions<PolicySubmissionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MemberRegistration> MemberRegistrations { get; set; } = null!;
        public virtual DbSet<Policy> Policies { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET647;Initial Catalog=PolicySubmission;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberRegistration>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__MemberRe__0CF04B185B4509A5");

                entity.ToTable("MemberRegistration");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Policy");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PolicyId).ValueGeneratedOnAdd();

                entity.Property(e => e.PolicyStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PremiumAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany()
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Policy__MemberId__33D4B598");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.UserName, "UQ__User__C9F284569175786E")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserRole)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
