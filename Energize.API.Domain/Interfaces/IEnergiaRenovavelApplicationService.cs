using Energize.API.Domain.Entities;
using Energize.API.Domain.Interfaces.Dtos;

namespace Energize.API.Domain.Interfaces
{
    public interface IEnergiaRenovavelApplicationService
    {
        IEnumerable<EnergiaRenovavelEntity> ObterTodosEnergiaRenovavel();
        EnergiaRenovavelEntity? ObterEnergiaRenovavelPorId(int id);
        EnergiaRenovavelEntity? SalvarDadosEnergiaRenovavel(IEnergiaRenovavelDto entity);
        EnergiaRenovavelEntity? EditarDadosEnergiaRenovavel(int id, IEnergiaRenovavelDto entity);
        EnergiaRenovavelEntity? DeletarDadosEnergiaRenovavel(int id);
        Task<Endereco?> ObterEnderecoPorCepAsync(string cep);
    }
}
