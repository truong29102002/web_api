using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace web_api.Models
{
    public partial class dbapiContext : DbContext
    {
        public dbapiContext()
        {
        }

        public dbapiContext(DbContextOptions<dbapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GiaoVien> GiaoViens { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=dbapi;Persist Security Info=True;User ID=sa;Password=12345678; Encrypt=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiaoVien>(entity =>
            {
                entity.ToTable("GiaoVien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.ToTable("SinhVien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(250)
                    .HasColumnName("diachi");

                entity.Property(e => e.Lop)
                    .HasMaxLength(10)
                    .HasColumnName("lop")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdGv).HasColumnName("id_gv");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.TrangThai).HasColumnName("trangThai");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_TaiKhoan_SinhVien");

                entity.HasOne(d => d.IdGvNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.IdGv)
                    .HasConstraintName("FK_TaiKhoan_GiaoVien1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
