using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energize.API.Domain.Interfaces.Dtos
{
    public interface IEnergiaRenovavelDto
    {
        string Nome { get; set; }
        string Descricao { get; set; }
        void Validation();
    }
}
