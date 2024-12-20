using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crypto.Models;

[Table("porte_feuille")]
public partial class PorteFeuille
{
    [Key]
    [Column("id_porte_feuille")]
    public int IdPorteFeuille { get; set; }

    [Column("id_cryptomonnaie")]
    public int IdCryptomonnaie { get; set; }

    [Column("id_utilisateur")]
    public int IdUtilisateur { get; set; }

    [ForeignKey("IdCryptomonnaie")]
    [InverseProperty("PorteFeuilles")]
    public virtual Cryptomonnaie IdCryptomonnaieNavigation { get; set; } = null!;

    [ForeignKey("IdUtilisateur")]
    [InverseProperty("PorteFeuilles")]
    public virtual Utilisateur IdUtilisateurNavigation { get; set; } = null!;

    [ForeignKey("IdPorteFeuille")]
    [InverseProperty("IdPorteFeuilles")]
    public virtual ICollection<TransactionCrypto> IdTransactionCryptos { get; set; } = new List<TransactionCrypto>();
}
