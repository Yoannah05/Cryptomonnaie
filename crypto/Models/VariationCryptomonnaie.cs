using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crypto.Models;

[Table("variation_cryptomonnaie")]
public partial class VariationCryptomonnaie
{
    [Key]
    [Column("id_variation_cryptomonnaie")]
    public int IdVariationCryptomonnaie { get; set; }

    [Column("variation")]
    [Precision(3, 2)]
    public decimal? Variation { get; set; }

    [Column("id_cryptomonnaie")]
    public int IdCryptomonnaie { get; set; }

    [ForeignKey("IdCryptomonnaie")]
    [InverseProperty("VariationCryptomonnaies")]
    public virtual Cryptomonnaie IdCryptomonnaieNavigation { get; set; } = null!;
}
