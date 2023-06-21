using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectChess.DBConnection;

public partial class ChessContext : DbContext
{
    public ChessContext()
    {
    }

    public ChessContext(DbContextOptions<ChessContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<Player> Player { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Chess;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     
        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_adresy");

            entity.ToTable("adress");

            entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_komentarze");

            entity.ToTable("comment");

            entity.Property(e => e.Id)
                   .ValueGeneratedOnAdd()
                     .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.Context)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("context");
            entity.Property(e => e.PartyId).HasColumnName("party_id");
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_partie");

            entity.ToTable("match");

            entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Player1Id).HasColumnName("player1_id");
            entity.Property(e => e.Player2Id).HasColumnName("player2_id");
            entity.Property(e => e.Result)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("result");

            entity.HasOne(d => d.Player1).WithMany(p => p.MatchPlayer1s)
                .HasForeignKey(d => d.Player1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_partie_szachiści1");

            entity.HasOne(d => d.Player2).WithMany(p => p.MatchPlayer2s)
                .HasForeignKey(d => d.Player2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_partie_szachiści2");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_szachiści");

            entity.ToTable("player");

            entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");

            entity.HasOne(d => d.Adress).WithMany(p => p.Players)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_szachiści_adresy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
