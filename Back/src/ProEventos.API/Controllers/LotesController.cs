using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotesController : ControllerBase
    {
        private readonly ILoteService _loteService;
        public LotesController(ILoteService LoteService)
        {
            _loteService = LoteService;

        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var lotes = await _loteService.GetLotesByEventoIdAsync(eventoId);
                if(lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500,$"Erro ao tentar recuperar Lotes. Erro: {ex.Message}");
            }
        }

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> SaveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotes = await _loteService.SaveLote(eventoId, models);
                if(lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500,$"Erro ao tentar Salvar Lotes. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{eventoId}/{loteId}")]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var lote = await _loteService.GetLoteByIdsAsync(eventoId, loteId);
                if(lote == null) return NoContent();

                if(await _loteService.DeleteLote(lote.EventoId, lote.Id)){
                    return Ok("Lote Deletado");
                }else{
                    throw new Exception("Ocorreu um problema nao especifico ao tentar deletar Lote.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(500,$"Erro ao tentar Deletar Lotes. Erro: {ex.Message}");
            }
        }
    }
}
