using System.ComponentModel.DataAnnotations;

namespace GestionBrasserie.Models;

public class Brasserie
{
    [Key] public int Idbrasserie { get; set; }
    public string nomBr { get; set; }

    public ICollection<Biere> Bieres { get; set; }
}