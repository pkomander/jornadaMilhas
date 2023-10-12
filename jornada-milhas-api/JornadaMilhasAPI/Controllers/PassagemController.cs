using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.Interface;

namespace JornadaMilhasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassagemController : ControllerBase
    {
        private readonly IPassagemService _passagem;
        public PassagemController(IPassagemService passagem)
        {
            _passagem = passagem;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PassagemDto dto)
        {
            try
            {
                var request = await _passagem.Add(dto);

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Passagem. Erro: {ex.Message}");
            }
        }

        [HttpGet("passagens")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var request = await _passagem.GetAll();

                if (request == null)
                    return NoContent();

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar as passagens. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var request = await _passagem.GetById(id);

                if (request == null)
                    return NotFound("Passagem não encontrado");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar a passagem. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PassagemDto passagemDto)
        {
            try
            {
                var request = await _passagem.Update(id, passagemDto);

                if (request == null)
                    return NotFound("Passagem não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar passagem. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var request = await _passagem.Delete(id);

                if (!request)
                    return NotFound("Passagem não encontrada");

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir passagem. Erro: {ex.Message}");
            }
        }
    }
}