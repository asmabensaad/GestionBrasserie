using GestionBrasserie.Models;
using GestionBrasserie.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionBrasserie.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrasserieController : ControllerBase
{
    private readonly IBrasserieService _brasserieService;

    public BrasserieController(IBrasserieService brassService)
    {
        _brasserieService = brassService;
    }

    /// <summary>
    /// biere a ajouter par brasseur
    /// </summary>
    /// <param name="brasserieId"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("{brasserieId}/biere")]
    public IActionResult AddBiere(int brasserieId, [FromBody] Biere model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        //verifier si le brasserie existe ou non
        var brasserie = _brasserieService.GetBrasseurById(brasserieId);

        if (brasserie == null)
        {
            return NotFound("Brasseur non trouvé");
        }


        var nouvelleBiere = new Biere
        {
            nomBiere = model.nomBiere,
            prixBiere = model.prixBiere,
            TeneurEnAlcool = model.TeneurEnAlcool,
            BrasserieId = brasserie.Idbrasserie
        };


        _brasserieService.AddBiere(brasserieId, nouvelleBiere);

        return Ok("Biere ajoutée avec succès");
    }

    /// <summary>
    /// Ajouter biere 
    /// </summary>
    /// <param name="nouvelleBiere"></param>
    /// <returns></returns>
    [HttpPost("Biere")]
    public IActionResult AjouterBiere([FromBody] Biere nouvelleBiere)
    {
        try
        {
            _brasserieService.AddBiere(nouvelleBiere);
            return Ok("Bière ajoutée avec succès.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erreur lors de l'ajout de la bière : {ex.Message}");
        }
    }

    /// <summary>
    /// biere a supprimer par brasserie
    /// </summary>
    /// <param name="idbrasserie"></param>
    /// <param name="idbiere"></param>
    /// <returns></returns>
    [HttpDelete("{idbrasserie}/{idbiere}")]
    public IActionResult DeleteBiere(int idbrasserie, int idbiere)
    {
        var brasserie = _brasserieService.GetBrasseurById(idbrasserie);

        if (brasserie == null)
        {
            return NotFound("Brasserie n'existe pas ");
        }
        else
        {
            try
            {
                _brasserieService.DeleteBiere(idbrasserie, idbiere);
                return Ok("biére supprimée avec succées");
            }
            catch (Exception e)
            {
                return BadRequest($"Erreur lors de la suppression de biere {e.Message}");
            }
        }
    }

    /// <summary>
    /// Get la liste des bieres par Brasserie 
    /// </summary>
    /// <param name="brasserieId"></param>
    /// <returns></returns>
    [HttpGet("brasserieId")]
    public IActionResult GetBieresByBrasserie(int brasserieId)
    {
        try
        {
            var bieres = _brasserieService.GetListbiereparbrasserie(brasserieId);
            return Ok(bieres);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erreur lors de la recuperation des bieres :{ex.Message}");
        }
    }


}