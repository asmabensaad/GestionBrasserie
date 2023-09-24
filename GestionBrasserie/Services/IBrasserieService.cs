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
    public void DeleteBiere(int brasserieid, int idbiere);

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
    /// Ajouter une vente avec une mise a jour automatique de quantite de stock restante
    /// </summary>
    /// <param name="idGrossiste"></param>
    /// <param name="idBiere"></param>
    /// <param name="qteVendue"></param>
    /// <param name="prixUnitaire"></param>
    /// <param name="dateVente"></param>
    public void AddVente(int idGrossiste, int idBiere, int qteVendue, decimal prixUnitaire, DateTime dateVente);

    /// <summary>
    /// obtenir la liste des information des bieres 
    /// </summary>
    /// <param name="idBieres"></param>
    /// <returns></returns>
    public List<Dictionary<string, object>> GetInfoBieres(List<int> idBieres);

    public Grossiste? GetGrossisteById(int grId);
    public Biere? GetBiereById(int idbiere);

    /// <summary>
    /// verifier si le grossiste et la biere en question existe dans la table stock
    /// </summary>
    /// <param name="idGr"></param>
    /// <param name="IdBiere"></param>
    /// <returns></returns>
    public StockGrossiste? GetstockGrossiste(int idGr, int IdBiere);
}