using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.Interface;

namespace JornadaMilhasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromocaoController : ControllerBase
    {
        private readonly IPromocoesService _promocoes;
        public PromocaoController(IPromocoesService promocoes)
        {
            _promocoes = promocoes;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PromocaoDto dto)
        {
            try
            {
                var request = await _promocoes.Add(dto);

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Promo��o. Erro: {ex.Message}");
            }
        }

        [HttpGet("promocoes")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var request = await _promocoes.GetAll();

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar as promoc�es. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var request = await _promocoes.GetById(id);

                if (request == null)
                    return NotFound("Promo��o n�o encontrado");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar a promo��o. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PromocaoDto promocaoDto)
        {
            try
            {
                var request = await _promocoes.Update(id, promocaoDto);

                if (request == null)
                    return NotFound("Promo��o n�o encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar promo��o. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var request = await _promocoes.Delete(id);

                if (!request)
                    return NotFound("Promoc�o n�o encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir promo��o. Erro: {ex.Message}");
            }
        }
    }
}