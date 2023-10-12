using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.Interface;

namespace JornadaMilhasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estado;
        public EstadoController(IEstadoService estado)
        {
            _estado = estado;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstadoDto dto)
        {
            try
            {
                var request = await _estado.Add(dto);

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Estado. Erro: {ex.Message}");
            }
        }

        [HttpGet("estados")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var request = await _estado.GetAll();

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar as estado. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var request = await _estado.GetById(id);

                if (request == null)
                    return NotFound("Estado não encontrado");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar a estado. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstadoDto estadoDto)
        {
            try
            {
                var request = await _estado.Update(id, estadoDto);

                if (request == null)
                    return NotFound("Estado não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar estado. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var request = await _estado.Delete(id);

                if (!request)
                    return NotFound("Estado não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir estado. Erro: {ex.Message}");
            }
        }
    }
}