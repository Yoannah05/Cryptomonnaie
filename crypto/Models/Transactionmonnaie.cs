using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crypto.Models;

[Table("transactionmonnaie")]
public partial class Transactionmonnaie
{
    [Key]
    [Column("id_transaction")]
    public int IdTransaction { get; set; }

    [Column("montant", TypeName = "money")]
    public decimal? Montant { get; set; }

    [Column("isentree")]
    public bool? Isentree { get; set; }

    [Column("id_utilisateur")]
    public int IdUtilisateur { get; set; }

    [ForeignKey("IdUtilisateur")]
    [InverseProperty("Transactionmonnaies")]
    public virtual Utilisateur IdUtilisateurNavigation { get; set; } = null!;
}
