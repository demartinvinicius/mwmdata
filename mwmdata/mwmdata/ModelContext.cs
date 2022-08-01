using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mwmdata
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ManufacturingResult> ManufacturingResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-P9RHEF5)(PORT = 1521))(CONNECT__DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE)));User Id=C##_VISUAL;Password=xyz;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##_VISUAL")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<ManufacturingResult>(entity =>
            {
                entity.ToTable("MANUFACTURING_RESULT", "TNT_OPERATIONAL");

                entity.HasIndex(e => e.ManufacturingOperationId, "IX_MANUFACTURING_RESULT_01");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.EffectiveData)
                    .HasColumnType("CLOB")
                    .HasColumnName("EFFECTIVE_DATA");

                entity.Property(e => e.EffectiveDataBkp)
                    .HasColumnType("CLOB")
                    .HasColumnName("EFFECTIVE_DATA_BKP");

                entity.Property(e => e.ManufacturingOperationId).HasColumnName("MANUFACTURING_OPERATION_ID");

                entity.Property(e => e.PlainData)
                    .HasColumnType("CLOB")
                    .HasColumnName("PLAIN_DATA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
