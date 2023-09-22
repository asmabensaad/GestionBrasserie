using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBrasserie.Models;

public class StockGrossiste
{
    [Key]
    [Column (Order = 0)]
    public int StockId { get; set; }
    [Key]
    [Column (Order=1)]
   
   
    public int QuantiteStock { get; set; }
    [ForeignKey("Biere")] 
    public int BiereId { get; set; }
   
    public Biere Biere { get; set; }
    
    [ForeignKey("Grossiste")] 
    public int IdGr { get; set; }
   
    public Grossiste Grossiste { get; set; }
}