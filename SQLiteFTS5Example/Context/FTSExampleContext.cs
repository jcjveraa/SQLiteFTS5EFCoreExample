using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SQLiteFTS5Example.Models;

namespace SQLiteFTS5Example.Context
{
    public partial class FTSExampleContext : DbContext
    {
        public FTSExampleContext()
        {
        }

        public FTSExampleContext(DbContextOptions<FTSExampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Songs> Songs { get; set; }
        public virtual DbSet<SongsFts5> SongsFts5 { get; set; }
        public virtual DbSet<SongsFts5Config> SongsFts5Config { get; set; }
        public virtual DbSet<SongsFts5Content> SongsFts5Content { get; set; }
        public virtual DbSet<SongsFts5Data> SongsFts5Data { get; set; }
        public virtual DbSet<SongsFts5Docsize> SongsFts5Docsize { get; set; }
        public virtual DbSet<SongsFts5Idx> SongsFts5Idx { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=subset_track_metadata.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Songs>(entity =>
            {
                entity.HasKey(e => e.TrackId);

                entity.ToTable("songs");

                entity.HasIndex(e => new { e.ArtistFamiliarity, e.ArtistHotttnesss })
                    .HasName("idx_familiarity");

                entity.HasIndex(e => new { e.ArtistHotttnesss, e.ArtistFamiliarity })
                    .HasName("idx_hotttnesss");

                entity.HasIndex(e => new { e.ArtistId, e.Release })
                    .HasName("idx_artist_id");

                entity.HasIndex(e => new { e.ArtistMbid, e.Release })
                    .HasName("idx_artist_mbid");

                entity.HasIndex(e => new { e.Duration, e.ArtistId })
                    .HasName("idx_duration");

                entity.HasIndex(e => new { e.Year, e.ArtistName })
                    .HasName("idx_year2");

                entity.HasIndex(e => new { e.ArtistName, e.Title, e.Release })
                    .HasName("idx_artist_name");

                entity.HasIndex(e => new { e.Title, e.ArtistName, e.Release })
                    .HasName("idx_title");

                entity.HasIndex(e => new { e.Year, e.ArtistId, e.Title })
                    .HasName("idx_year");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.Property(e => e.ArtistFamiliarity).HasColumnName("artist_familiarity");

                entity.Property(e => e.ArtistHotttnesss).HasColumnName("artist_hotttnesss");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.ArtistMbid).HasColumnName("artist_mbid");

                entity.Property(e => e.ArtistName).HasColumnName("artist_name");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Release).HasColumnName("release");

                entity.Property(e => e.SongId).HasColumnName("song_id");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("int");
            });

            modelBuilder.Entity<SongsFts5>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("songs_fts5");

                entity.Property(e => e.ArtistName).HasColumnName("artist_name");

                entity.Property(e => e.Release).HasColumnName("release");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.TrackId).HasColumnName("track_id");
            });

            modelBuilder.Entity<SongsFts5Config>(entity =>
            {
                entity.HasKey(e => e.K);

                entity.ToTable("songs_fts5_config");

                entity.Property(e => e.K).HasColumnName("k");

                entity.Property(e => e.V).HasColumnName("v");
            });

            modelBuilder.Entity<SongsFts5Content>(entity =>
            {
                entity.ToTable("songs_fts5_content");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.C0).HasColumnName("c0");

                entity.Property(e => e.C1).HasColumnName("c1");

                entity.Property(e => e.C2).HasColumnName("c2");

                entity.Property(e => e.C3).HasColumnName("c3");
            });

            modelBuilder.Entity<SongsFts5Data>(entity =>
            {
                entity.ToTable("songs_fts5_data");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Block).HasColumnName("block");
            });

            modelBuilder.Entity<SongsFts5Docsize>(entity =>
            {
                entity.ToTable("songs_fts5_docsize");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Sz).HasColumnName("sz");
            });

            modelBuilder.Entity<SongsFts5Idx>(entity =>
            {
                entity.HasKey(e => new { e.Segid, e.Term });

                entity.ToTable("songs_fts5_idx");

                entity.Property(e => e.Segid).HasColumnName("segid");

                entity.Property(e => e.Term).HasColumnName("term");

                entity.Property(e => e.Pgno).HasColumnName("pgno");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
