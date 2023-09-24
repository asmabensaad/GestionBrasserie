using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBrasserie.Models;

public class Biere
{
    [Key] public int BiereId { get; set; }
    public string nomBiere { get; set; }
    [Column(TypeName = "decimal(18,2)")] public decimal prixBiere { get; set; }
    public double TeneurEnAlcool { get; set; }

    [ForeignKey("Brasserie")] public int BrasserieId { get; set; }
}