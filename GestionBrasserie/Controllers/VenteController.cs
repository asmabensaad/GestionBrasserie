using GestionBrasserie.Models;
using GestionBrasserie.Services;
using Microsoft.AspNetCore.Mvc;


namespace GestionBrasserie.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VenteController :ControllerBase
{
    
    private readonly IBrasserieService _brasserieService;

    public VenteController (IBrasserieService brasserieService)
    {
        _brasserieService = brasserieService;
    }


    [HttpPost( "ajouter-vente")]
    public IActionResult AddVente(  [FromBody] Vente vente)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        else
        {
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
        
      
         
    }
}