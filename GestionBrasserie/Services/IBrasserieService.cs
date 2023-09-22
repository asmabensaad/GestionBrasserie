using GestionBrasserie.Models;

namespace GestionBrasserie.Services;

public interface IBrasserieService
{
    
    public void AddBiere(int brasserieid, Biere biere);
    public void DeleteBiere();
    public List<Biere> GetListbiere(int brasserieId);
    public void UpdateStock(int idgr, int idstock, int idBiere);

    public Brasserie GetBrasseurById(int brasseurId);
    public void AddBiere(Biere biere);

}