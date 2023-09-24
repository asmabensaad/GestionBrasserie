using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBrasserie.Models;

public class Vente
{
    [Key] [Column(Order = 0)] public int Idvente { get; set; }

    [Key]
    [Column(Order = 1)]
    [ForeignKey("IdGr")]
    public int IdGr { get; set; }

    [Key]
    [Column(Order = 2)]
    [ForeignKey("BiereId")]
    public int BiereId { get; set; }

    public int Qtevendu { get; set; }
    [Column(TypeName = "decimal(18,2)")] public decimal Prixunitaire { get; set; }
    public DateTime DateVente { get; set; }
    [Column(TypeName = "decimal(18,2)")] public decimal MontantTotal { get; set; }
}