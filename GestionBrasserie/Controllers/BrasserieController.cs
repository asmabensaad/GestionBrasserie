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
        
        
        [HttpPost("{brasserieId}/biere")]
        public IActionResult AddBiere(int brasserieId, [FromBody] Biere model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
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



        [HttpPost]
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


       

}