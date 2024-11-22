using Energize.API.Domain.Entities;
using Energize.API.Domain.Interfaces;
using Energize.EnergiaRenovavel.Application.Dto;
using Energize.EnergiaRenovavel.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Energize.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergiaRenovavelController : ControllerBase
    {
        private readonly IEnergiaRenovavelApplicationService _energiaRenovavelApplicationService;

        public EnergiaRenovavelController(IEnergiaRenovavelApplicationService EnergiaRenovavelApplicationService)
        {
            _energiaRenovavelApplicationService = EnergiaRenovavelApplicationService;
        }

        /// <summary>
        /// Metodo para obter todos os dados da energia
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<EnergiaRenovavelEntity>>]
        public IActionResult Get()
        {
            var energiaRenovaveis = _energiaRenovavelApplicationService.ObterTodosEnergiaRenovavel();

            if (energiaRenovaveis is not null)
                return Ok(energiaRenovaveis);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Método para obter uma energia
        /// </summary>
        /// <param name="id">Identificador da energia</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<EnergiaRenovavelEntity>]

        public IActionResult GetPorId(int id)
        {
            var energiaRenovaveis = _energiaRenovavelApplicationService.ObterEnergiaRenovavelPorId(id);

            if (energiaRenovaveis is not null)
                return Ok(energiaRenovaveis);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Método para salvar a energia
        /// </summary>
        /// <param name="entity">Modelo de dados da Energia</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<EnergiaRenovavelEntity>]
        public IActionResult Post(EnergiaRenovavelDto entity)
        {
            try
            {
                var energiaRenovaveis = _energiaRenovavelApplicationService.SalvarDadosEnergiaRenovavel(entity);

                if (energiaRenovaveis is not null)
                    return Ok(energiaRenovaveis);

                return BadRequest("Não foi possível salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,

                });
            }
        }

        /// <summary>
        /// Método para editar a energia
        /// </summary>
        /// <param name="id">Identificador da Energia</param>
        /// <param name="entity">Modelo de dados da Energia</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<EnergiaRenovavelEntity>]
        public IActionResult Put(int id, EnergiaRenovavelDto entity)
        {
            try
            {
                var energiaRenovaveis = _energiaRenovavelApplicationService.EditarDadosEnergiaRenovavel(id, entity);

                if (energiaRenovaveis is not null)
                    return Ok(energiaRenovaveis);

                return BadRequest("Não foi possível editar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,

                });
            }
        }

        /// <summary>
        /// Método para deletar uma energia
        /// </summary>
        /// <param name="id">Identificador da energia</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<EnergiaRenovavelEntity>]

        public IActionResult Delete(int id)
        {
            var energiaRenovaveis = _energiaRenovavelApplicationService.DeletarDadosEnergiaRenovavel(id);

            if (energiaRenovaveis is not null)
                return Ok(energiaRenovaveis);

            return BadRequest("Não foi possível deletar os dados");
        }

        [HttpGet("busca/endereco/{cep}")]
        [Produces<Endereco>]
        public async Task<IActionResult> GetDataService(string cep)
        {
            var endereco = await _energiaRenovavelApplicationService.ObterEnderecoPorCepAsync(cep);

            if (endereco is not null)
                return Ok(endereco);

            return BadRequest("Não foi possivel obter os dados do endereço");
        }
    }
}
