using GestionBrasserie.Models;

namespace GestionBrasserie.Services;
/// <summary>
/// Brasserie Service
/// </summary>
public interface IBrasserieService
{
    /// <summary>
    /// add biere par brasserie
    /// </summary>
    /// <param name="brasserieid"></param>
    /// <param name="biere"></param>
    public void AddBiere(int brasserieid, Biere biere);
    /// <summary>
    /// supprimer Biere par Brasserie
    /// </summary>
    public void DeleteBiere(int brasserieid ,int  idbiere);
    /// <summary>
    /// Get la liste des biere par brasserieId
    /// </summary>
    /// <param name="brasserieId"></param>
    /// <returns></returns>
    public List<Biere> GetListbiereparbrasserie(int brasserieId);
    
    /// <summary>
    /// get brasserie by id
    /// </summary>
    /// <param name="brasseurId"></param>
    /// <returns></returns>

    public Brasserie GetBrasseurById(int brasseurId);
    public void AddBiere(Biere biere);
    /// <summary>
    /// mettre a jour le stock de grossiste 
    /// </summary>
    /// <param name="idgr"></param>
    /// <param name="idstock"></param>
    /// <param name="idBiere"></param>
    public void UpdateStock(int idgr, int idstock, int idBiere);
    /// <summary>
    /// Ajouter une vente 
    /// </summary>
    /// <param name="idGrossiste"></param>
    /// <param name="idBiere"></param>
    /// <param name="qteVendue"></param>
    /// <param name="prixUnitaire"></param>
    /// <param name="dateVente"></param>

    public void AddVente(int idGrossiste, int idBiere, int qteVendue, decimal prixUnitaire, DateTime dateVente);

    public Grossiste? GetGrossisteById(int grId);
    public Biere? GetBiereById(int idbiere);
}