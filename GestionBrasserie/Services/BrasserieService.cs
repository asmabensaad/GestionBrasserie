using GestionBrasserie.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionBrasserie.Services;
/// <inheritdoc cref="IBrasserieService"/>
public class BrasserieService :IBrasserieService
{
    private readonly GestionBrasserieDbContext _gestionBrasserieDb;

    public BrasserieService(GestionBrasserieDbContext gestionBrasserieDb)
    {
        _gestionBrasserieDb = gestionBrasserieDb;
    }
    /// <inheritdoc cref="IBrasserieService.AddBiere"/>
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
            Console.WriteLine("brasserie  n'existe pas");
        }
    }
    
    /// <inheritdoc cref="IBrasserieService.GetBrassseurById"/>
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

    public void DeleteBiere(int idbrasseur ,int idbiere)
    {
        var brasserie = _gestionBrasserieDb.Brasseries.FirstOrDefault(b => b.Idbrasserie == idbrasseur);
      
        var bieretodelete = _gestionBrasserieDb.Bieres.FirstOrDefault(b => b.BiereId == idbiere);
        if (bieretodelete != null  && brasserie  !=null)
        {
            _gestionBrasserieDb.Bieres.Remove(bieretodelete);
            _gestionBrasserieDb.SaveChanges();
        }
        else
        {
            throw new Exception("biere n'existe pas");
        }
       
    }

    public List<Biere> GetListbiereparbrasserie(int brasserieId)
    {
        return _gestionBrasserieDb.Bieres.Where(b => b.BrasserieId == brasserieId).ToList();
    }

    public void UpdateStock(int idgr, int idstock, int idBiere)
    {
        throw new NotImplementedException();
    }
}