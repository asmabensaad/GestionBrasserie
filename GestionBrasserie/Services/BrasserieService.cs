using GestionBrasserie.Models;

namespace GestionBrasserie.Services;

public class BrasserieService :IBrasserieService
{
    private readonly GestionBrasserieDbContext _gestionBrasserieDb;

    public BrasserieService(GestionBrasserieDbContext gestionBrasserieDb)
    {
        _gestionBrasserieDb = gestionBrasserieDb;
    }
    public void AddBiere(int brasserieid, Biere biere)
    {
        var brasserie = _gestionBrasserieDb.Brasseries.FirstOrDefault(b => b.Idbrasserie == brasserieid);
        if(brasserie !=null)
        {
            biere.BrasserieId = brasserieid;
            _gestionBrasserieDb.Bieres.Add(biere);
            _gestionBrasserieDb.SaveChanges();
        }
        else
        {
            Console.WriteLine("brasseur n'existe pas");
        }
    }
    
    
    public Brasserie GetBrasseurById(int brasseurId)
    {
     
        var brasserie = _gestionBrasserieDb.Brasseries.FirstOrDefault(b => b.Idbrasserie == brasseurId);

        return brasserie;
    }

    public void AddBiere(Biere biere)
    {
        _gestionBrasserieDb.Bieres.Add(biere);
        _gestionBrasserieDb.SaveChanges();
       
    }

    public void DeleteBiere()
    {
        throw new NotImplementedException();
    }

    public List<Biere> GetListbiere(int brasserieId)
    {
        throw new NotImplementedException();
    }

    public void UpdateStock(int idgr, int idstock, int idBiere)
    {
        throw new NotImplementedException();
    }
}