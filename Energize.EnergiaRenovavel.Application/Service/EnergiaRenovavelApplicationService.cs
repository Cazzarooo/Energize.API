using Energize.API.Domain.Entities;
using Energize.API.Domain.Interfaces;
using Energize.API.Domain.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energize.EnergiaRenovavel.Application.Service
{
    public class EnergiaRenovavelApplicationService : IEnergiaRenovavelApplicationService
    {
        private readonly IEnergiaRenovavelRepository _energiaRenovavelRepository;
        private readonly IEnderecoService _enderecoService;

        public EnergiaRenovavelApplicationService(IEnergiaRenovavelRepository energiaRenovavelRepository, IEnderecoService enderecoService)
        {
            _energiaRenovavelRepository = energiaRenovavelRepository;
            _enderecoService = enderecoService;
        }
        public EnergiaRenovavelEntity? DeletarDadosEnergiaRenovavel(int id)
        {
            return _energiaRenovavelRepository.DeletarDados(id);
        }

        public EnergiaRenovavelEntity? EditarDadosEnergiaRenovavel(int id, IEnergiaRenovavelDto entity)
        {
            entity.Validation();

            return _energiaRenovavelRepository.EditarDados(new EnergiaRenovavelEntity
            {
                Id = id,
                Nome = entity.Nome,
                Descricao = entity.Descricao,
            });
        }

        public EnergiaRenovavelEntity? ObterEnergiaRenovavelPorId(int id)
        {
            return _energiaRenovavelRepository.ObterPorId(id);
        }

        public IEnumerable<EnergiaRenovavelEntity> ObterTodosEnergiaRenovavel()
        {
            return _energiaRenovavelRepository.ObterTodos();
        }

        public EnergiaRenovavelEntity? SalvarDadosEnergiaRenovavel(IEnergiaRenovavelDto entity)
        {
            entity.Validation();

            return _energiaRenovavelRepository.SalvarDados(new EnergiaRenovavelEntity
            {
                Nome = entity.Nome,
                Descricao = entity.Descricao,
            });
        }

        public async Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
        {
            var endereco = await _enderecoService.ObterEnderecoPorCepAsync(cep);

            if (endereco is not null)
                return endereco;

            return null;
        }
    }
}
