using Energize.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energize.API.Domain.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco?> ObterEnderecoPorCepAsync(string cep);
    }
}
