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
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Promoção. Erro: {ex.Message}");
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar as promocões. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var request = await _promocoes.GetById(id);

                if (request == null)
                    return NotFound("Promoção não encontrado");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar a promoção. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PromocaoDto promocaoDto)
        {
            try
            {
                var request = await _promocoes.Update(id, promocaoDto);

                if (request == null)
                    return NotFound("Promoção não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar promoção. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var request = await _promocoes.Delete(id);

                if (!request)
                    return NotFound("Promocão não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir promoção. Erro: {ex.Message}");
            }
        }
    }
}