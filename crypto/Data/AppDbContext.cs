using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crypto.Models;

namespace crypto.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cryptomonnaie> Cryptomonnaies { get; set; }

    public virtual DbSet<PorteFeuille> PorteFeuilles { get; set; }

    public virtual DbSet<TransactionCrypto> TransactionCryptos { get; set; }

    public virtual DbSet<Transactionmonnaie> Transactionmonnaies { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<VariationCryptomonnaie> VariationCryptomonnaies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cryptomonnaie>(entity =>
        {
            entity.HasKey(e => e.IdCryptomonnaie).HasName("cryptomonnaie_pkey");
        });

        modelBuilder.Entity<PorteFeuille>(entity =>
        {
            entity.HasKey(e => e.IdPorteFeuille).HasName("porte_feuille_pkey");

            entity.HasOne(d => d.IdCryptomonnaieNavigation).WithMany(p => p.PorteFeuilles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("porte_feuille_id_cryptomonnaie_fkey");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.PorteFeuilles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("porte_feuille_id_utilisateur_fkey");

            entity.HasMany(d => d.IdTransactionCryptos).WithMany(p => p.IdPorteFeuilles)
                .UsingEntity<Dictionary<string, object>>(
                    "Asso2",
                    r => r.HasOne<TransactionCrypto>().WithMany()
                        .HasForeignKey("IdTransactionCrypto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("asso_2_id_transaction_crypto_fkey"),
                    l => l.HasOne<PorteFeuille>().WithMany()
                        .HasForeignKey("IdPorteFeuille")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("asso_2_id_porte_feuille_fkey"),
                    j =>
                    {
                        j.HasKey("IdPorteFeuille", "IdTransactionCrypto").HasName("asso_2_pkey");
                        j.ToTable("asso_2");
                        j.IndexerProperty<int>("IdPorteFeuille").HasColumnName("id_porte_feuille");
                        j.IndexerProperty<int>("IdTransactionCrypto").HasColumnName("id_transaction_crypto");
                    });
        });

        modelBuilder.Entity<TransactionCrypto>(entity =>
        {
            entity.HasKey(e => e.IdTransactionCrypto).HasName("transaction_crypto_pkey");
        });

        modelBuilder.Entity<Transactionmonnaie>(entity =>
        {
            entity.HasKey(e => e.IdTransaction).HasName("transactionmonnaie_pkey");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.Transactionmonnaies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactionmonnaie_id_utilisateur_fkey");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("utilisateur_pkey");
        });

        modelBuilder.Entity<VariationCryptomonnaie>(entity =>
        {
            entity.HasKey(e => e.IdVariationCryptomonnaie).HasName("variation_cryptomonnaie_pkey");

            entity.HasOne(d => d.IdCryptomonnaieNavigation).WithMany(p => p.VariationCryptomonnaies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variation_cryptomonnaie_id_cryptomonnaie_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
