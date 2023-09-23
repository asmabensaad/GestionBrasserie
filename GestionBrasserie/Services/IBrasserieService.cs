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
    /// 
    /// </summary>
    public void DeleteBiere(int brasserieid ,int  idbiere);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="brasserieId"></param>
    /// <returns></returns>
    public List<Biere> GetListbiereparbrasserie(int brasserieId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="idgr"></param>
    /// <param name="idstock"></param>
    /// <param name="idBiere"></param>
    public void UpdateStock(int idgr, int idstock, int idBiere);
    /// <summary>
    /// get brasserie by id
    /// </summary>
    /// <param name="brasseurId"></param>
    /// <returns></returns>

    public Brasserie GetBrasseurById(int brasseurId);
    public void AddBiere(Biere biere);

}