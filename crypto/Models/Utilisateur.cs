using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace crypto.Models;

[Table("utilisateur")]
public partial class Utilisateur
{
    [Key]
    [Column("id_utilisateur")]
    public int IdUtilisateur { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string? Email { get; set; }

    [Column("nom")]
    [StringLength(50)]
    public string? Nom { get; set; }

    [Column("prenom")]
    [StringLength(50)]
    public string? Prenom { get; set; }

    [InverseProperty("IdUtilisateurNavigation")]
    public virtual ICollection<PorteFeuille> PorteFeuilles { get; set; } = new List<PorteFeuille>();

    [InverseProperty("IdUtilisateurNavigation")]
    public virtual ICollection<Transactionmonnaie> Transactionmonnaies { get; set; } = new List<Transactionmonnaie>();
}
