using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Music.Models
{
    public partial class SongContext1Context : DbContext
    {
        public SongContext1Context()
        {
        }

        public SongContext1Context(DbContextOptions<SongContext1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SongContext-1;Trusted_Connection=True;MultipleActiveResultSets=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Label>(entity =>
            {
                entity.ToTable("Label");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Artist).IsRequired();

                entity.Property(e => e.LabelName).IsRequired();
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LabelId).HasColumnName("LabelID");

                entity.Property(e => e.ReleaseDate).HasColumnName("releaseDate");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Label)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.LabelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Song_Label");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
