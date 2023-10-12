using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.Interface;

namespace JornadaMilhasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepoimentoController : ControllerBase
    {
        private readonly IDepoimentoService _depoimento;
        public DepoimentoController(IDepoimentoService depoimento)
        {
            _depoimento = depoimento;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepoimentoDto dto)
        {
            try
            {
                var request = await _depoimento.Add(dto);

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Depoimento. Erro: {ex.Message}");
            }
        }

        [HttpGet("Depoimentos")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var request = await _depoimento.GetAll();

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar as Depoimentos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var request = await _depoimento.GetById(id);

                if (request == null)
                    return NotFound("Depoimento não encontrado");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar a Depoimento. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepoimentoDto depoimentoDto)
        {
            try
            {
                var request = await _depoimento.Update(id, depoimentoDto);

                if (request == null)
                    return NotFound("Depoimento não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar depoimento. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var request = await _depoimento.Delete(id);

                if (!request)
                    return NotFound("Depoimento não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir depoimento. Erro: {ex.Message}");
            }
        }
    }
}