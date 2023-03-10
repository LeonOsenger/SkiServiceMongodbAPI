using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiServiceMongodbAPI.Models;
using SkiServiceMongodbAPI.Services;

namespace SkiServiceMongodbAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class DienstleistungenController : ControllerBase
    {
        private readonly DienstleistungenService _dienstleistungenService;

        public DienstleistungenController(DienstleistungenService DiensleistungsService)
        {
            _dienstleistungenService = DiensleistungsService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Dienstleistungen>> Get() =>
            await _dienstleistungenService.GetAsync();
        
        [AllowAnonymous]
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Dienstleistungen>> Get(string id)
        {
            var dienstleistung = await _dienstleistungenService.GetAsync(id);

            if (dienstleistung is null)
            {
                return NotFound();
            }

            return dienstleistung;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(Dienstleistungen newDienstleistung)
        {
            await _dienstleistungenService.CreateAsync(newDienstleistung);

            return CreatedAtAction(nameof(Get), new { id = newDienstleistung.Id }, newDienstleistung);
        }

        [Authorize]
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Dienstleistungen updatedDienstleistung)
        {
            var dienstleistung = await _dienstleistungenService.GetAsync(id);

            if (dienstleistung is null)
            {
                return NotFound();
            }

            updatedDienstleistung.Id = dienstleistung.Id;

            await _dienstleistungenService.UpdateAsync(id, updatedDienstleistung);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var dienstleistung = await _dienstleistungenService.GetAsync(id);

            if (dienstleistung is null)
            {
                return NotFound();
            }

            await _dienstleistungenService.RemoveAsync(id);

            return NoContent();
        }
    }
}
