using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crypto.Models;

[Table("cryptomonnaie")]
public partial class Cryptomonnaie
{
    [Key]
    [Column("id_cryptomonnaie")]
    public int IdCryptomonnaie { get; set; }

    [Column("nom_crypto")]
    [StringLength(50)]
    public string? NomCrypto { get; set; }

    [Column("valeur_initiale", TypeName = "money")]
    public decimal? ValeurInitiale { get; set; }

    [InverseProperty("IdCryptomonnaieNavigation")]
    public virtual ICollection<PorteFeuille> PorteFeuilles { get; set; } = new List<PorteFeuille>();

    [InverseProperty("IdCryptomonnaieNavigation")]
    public virtual ICollection<VariationCryptomonnaie> VariationCryptomonnaies { get; set; } = new List<VariationCryptomonnaie>();
}
