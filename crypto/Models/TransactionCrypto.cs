using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crypto.Models;

[Table("transaction_crypto")]
public partial class TransactionCrypto
{
    [Key]
    [Column("id_transaction_crypto")]
    public int IdTransactionCrypto { get; set; }

    [Column("montant", TypeName = "money")]
    public decimal Montant { get; set; }

    [Column("isentree")]
    [StringLength(50)]
    public string? Isentree { get; set; }

    [ForeignKey("IdTransactionCrypto")]
    [InverseProperty("IdTransactionCryptos")]
    public virtual ICollection<PorteFeuille> IdPorteFeuilles { get; set; } = new List<PorteFeuille>();
}
