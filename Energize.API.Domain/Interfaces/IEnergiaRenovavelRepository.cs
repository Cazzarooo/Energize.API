using Energize.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energize.API.Domain.Interfaces
{
    public interface IEnergiaRenovavelRepository
    {
        IEnumerable<EnergiaRenovavelEntity> ObterTodos();
        EnergiaRenovavelEntity? ObterPorId(int id);
        EnergiaRenovavelEntity? SalvarDados(EnergiaRenovavelEntity entity);
        EnergiaRenovavelEntity? EditarDados(EnergiaRenovavelEntity entity);
        EnergiaRenovavelEntity? DeletarDados(int id);

    }
}
