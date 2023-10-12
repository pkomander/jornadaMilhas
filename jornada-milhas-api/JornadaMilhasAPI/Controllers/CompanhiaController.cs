using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.Interface;

namespace JornadaMilhasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanhiaController : ControllerBase
    {
        private readonly ICompanhiaService _companhia;
        public CompanhiaController(ICompanhiaService companhia)
        {
            _companhia = companhia;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanhiaDto dto)
        {
            try
            {
                var request = await _companhia.Add(dto);

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Companhia. Erro: {ex.Message}");
            }
        }

        [HttpGet("companhias")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var request = await _companhia.GetAll();

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar as Companhias. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var request = await _companhia.GetById(id);

                if (request == null)
                    return NotFound("Companhia não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar a Companhia. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CompanhiaDto companhiaDto)
        {
            try
            {
                var request = await _companhia.Update(id, companhiaDto);

                if (request == null)
                    return NotFound("Companhia não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar companhia. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var request = await _companhia.Delete(id);

                if (!request)
                    return NotFound("Companhia não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir companhia. Erro: {ex.Message}");
            }
        }
    }
}