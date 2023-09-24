using GestionBrasserie.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionBrasserie.Services;

/// <inheritdoc cref="IBrasserieService"/>
public class BrasserieService : IBrasserieService
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
        if (brasserie != null)
        {
            biere.BrasserieId = brasserieid;
            _gestionBrasserieDb.Bieres.Add(biere);
            _gestionBrasserieDb.SaveChanges();
        }
        else
        {
            Console.WriteLine("brasserie n'existe pas");
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

    /// <inheritdoc cref="IBrasserieService.DeleteBiere"/>
    public void DeleteBiere(int idbrasseur, int idbiere)
    {
        var brasserie = _gestionBrasserieDb.Brasseries.FirstOrDefault(b => b.Idbrasserie == idbrasseur);

        var bieretodelete = _gestionBrasserieDb.Bieres.FirstOrDefault(b => b.BiereId == idbiere);
        if (bieretodelete != null && brasserie != null)
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


    /// <inheritdoc cref="IBrasserieService.AddVente"/>
    public void AddVente(int idGrossiste, int idBiere, int qteVendue, decimal prixUnitaire, DateTime dateVente)
    {
        var grossiste = _gestionBrasserieDb.Grossistes.Any(g => g.IdGr == idGrossiste);
        var biere = _gestionBrasserieDb.Bieres.Any(b => b.BiereId == idBiere);

        var stockGrossiste =
            _gestionBrasserieDb.StockGrossistes.FirstOrDefault(s => s.BiereId == idBiere && s.IdGr == idGrossiste);
        if (!biere || !grossiste || stockGrossiste == null || stockGrossiste.QuantiteStock < qteVendue)
        {
            throw new Exception("La biere specifié n'existe pas ou n'est pas disponible dans le stock du grossiste ");
        }
        else
        {
            var vente = new Vente
            {
                IdGr = idGrossiste,
                BiereId = idBiere,
                Qtevendu = qteVendue,
                Prixunitaire = prixUnitaire,
                DateVente = dateVente,
                MontantTotal = qteVendue * prixUnitaire
            };
            _gestionBrasserieDb.Add(vente);
            stockGrossiste.QuantiteStock -= qteVendue;
            _gestionBrasserieDb.SaveChanges();
        }
    }

    public Grossiste? GetGrossisteById(int gr)
    {
        var grossiste = _gestionBrasserieDb.Grossistes.FirstOrDefault(g => g.IdGr == gr);
        return grossiste;
    }

    public Biere? GetBiereById(int idbiere)
    {
        var biere = _gestionBrasserieDb.Bieres.FirstOrDefault(b => b.BiereId == idbiere);
        return biere;
    }

    /// <inheritdoc cref="IBrasserieService.GetInfoBieres"/>
    public List<Dictionary<string, object>> GetInfoBieres(List<int> idBieres)
    {
        var infoBieres = _gestionBrasserieDb.Bieres.Where(b => idBieres.Contains(b.BiereId))
            .Select(b => new Dictionary<string, object>
            {
                { "BiereId", b.BiereId },
                { "nomBiere", b.nomBiere },
                { "prixBiere", b.prixBiere },
                { "TeneurEnAlcool", b.TeneurEnAlcool },
            }).ToList();
        return infoBieres;
    }

    /// <inheritdoc cref="IBrasserieService.GetstockGrossiste"/>
    public StockGrossiste? GetstockGrossiste(int idGr, int idBiere)
    {
        var stockgrossiste = _gestionBrasserieDb.StockGrossistes.Include(s => s.Biere)
            .FirstOrDefault(s => s.IdGr == idGr && s.BiereId == idBiere);
        return stockgrossiste;
    }
}