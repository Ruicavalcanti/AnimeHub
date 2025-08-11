using AnimeHub.Application.Animes.Commands;
using AnimeHub.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.IO;
namespace AnimeHub.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public AnimeController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna animes filtrando por id, nome e/ou diretor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <param name="diretor"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<ActionResult> GetAnimeByFilter(
        [FromQuery] int? id,
        [FromQuery] string? nome,
        [FromQuery] string? diretor)
        {
            try
            {
                var animes = await _unitOfWork.AnimeRepository.GetAnimeByFilter(id, nome, diretor);

                if (!animes.Any())
                    return NotFound("Nenhum anime encontrado com os critérios informados.");

                return Ok(animes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        /// <summary>
        /// retorna todos os animes 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAnime()
        {
            try
            {
                var animes = await _unitOfWork.AnimeRepository.GetAnimes();
                return animes != null ? Ok(animes) : NotFound("Animes não encontrado");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao criar anime");
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAnime(CreateAnimeCommand command)
        {
            try
            {
                var createAnime = await _mediator.Send(command);
                Log.Information("Anime criado: {AnimeName} pelo usuário {User}", command.Nome, User.Identity?.Name ?? "Anonimo");
                return CreatedAtAction(nameof(GetAnime), new { id = createAnime.Id }, createAnime);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAnime(int id, UpdateAnimeCommand command)
        {
            try
            {
                command.Id = id;
                var updateAnime = await _mediator.Send(command);
                Log.Information("Anime atualizado: {AnimeName} pelo usuário {User}", command.Nome, User.Identity?.Name ?? "Anonimo");
                return updateAnime != null ? Ok(updateAnime) : NotFound("Anime não encontrado");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao atualizar anime id {AnimeId}", id);
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnime(int id)
        {
            try
            {
                var command = new DeleteAnimeCommand { Id = id };
                var deleteAnime = await _mediator.Send(command);
                Log.Information("Anime deletado: {AnimeName} pelo usuário {User}", User.Identity?.Name ?? "Anonimo");
                return deleteAnime != null ? Ok(deleteAnime) : NotFound("Anime não encontrado");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao deletar anime id {AnimeId}", id);
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
