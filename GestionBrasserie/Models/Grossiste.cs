using System.ComponentModel.DataAnnotations;

namespace GestionBrasserie.Models;

public class Grossiste
{
    [Key]
    public int IdGr { get; set; }
    public string nomGR { get; set; }
   
    
    public ICollection<StockGrossiste> stocks { get; set; }
}