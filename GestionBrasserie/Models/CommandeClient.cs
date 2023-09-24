namespace GestionBrasserie.Models;

public class CommandeClient
{
    public int IdGr { get; set; }
    public List<int> IdBieres { get; set; }
    public List<int> Quantite { get; set; }
}