using GestionBrasserie.Models;
using GestionBrasserie.Services;
using Microsoft.AspNetCore.Mvc;


namespace GestionBrasserie.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VenteController : ControllerBase
{
    private readonly IBrasserieService _brasserieService;

    public VenteController(IBrasserieService brasserieService)
    {
        _brasserieService = brasserieService;
    }

    /// <summary>
    /// ajout de vente
    /// </summary>
    /// <param name="vente"></param>
    /// <returns></returns>
    [HttpPost("ajouter-vente")]
    public IActionResult AddVente([FromBody] Vente vente)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _brasserieService.AddVente(vente.IdGr, vente.BiereId, vente.Qtevendu, vente.Prixunitaire,
                vente.DateVente);
            return Ok("Vente ajoutée avec succès !");
        }
        catch (Exception e)
        {
            return BadRequest($"Erreur lors de l'ajout de vente : {e.Message}");
        }
    }

    /// <summary>
    /// devis de client
    /// </summary>
    /// <param name="commandeClientModel"></param>
    /// <returns></returns>
    [HttpPost("devis-client")]
    public IActionResult DevisClient([FromBody] CommandeClient commandeClientModel)
    {
        try
        {
            var grossiste = _brasserieService.GetGrossisteById(commandeClientModel.IdGr);
            if (grossiste == null)
            {
                return BadRequest("Grossiste specifié n'existe pas ");
            }

            if (commandeClientModel.IdBieres == null || commandeClientModel.IdBieres.Count == 0)
            {
                return BadRequest("la commande ne peut pas étre vide");
            }

            if (commandeClientModel.IdBieres.Distinct().Count() != commandeClientModel.IdBieres.Count)
            {
                return BadRequest("Il ne peut y avoir de doublon dans la commande");
            }

            var infoBieres = _brasserieService.GetInfoBieres(commandeClientModel.IdBieres);
            foreach (var infoBiere in infoBieres)
            {
                int idBiere = (int)infoBiere["BiereId"];
                var stockGrossiste = _brasserieService.GetstockGrossiste(commandeClientModel.IdGr, idBiere);
                if (stockGrossiste == null)
                {
                    return BadRequest($"la biere avec l'id {idBiere} n'est pas vendue par le grossiste specifié");
                }
            }

            decimal montantTotal = 0;
            for (int i = 0; i < commandeClientModel.IdBieres.Count; i++)
            {
                montantTotal += (decimal)infoBieres[i]["prixBiere"] * commandeClientModel.Quantite[i];
            }

            if (commandeClientModel.IdBieres.Count > 20)
            {
                montantTotal *= 0.8m;
            }
            else if (commandeClientModel.IdBieres.Count > 10)
            {
                montantTotal *= 0.9m;
            }

            return Ok(new { MontantTotal = montantTotal, Devis = "Devis generé avec succé." });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erreur lors de la demande de devis : {ex.Message}");
        }
    }
}