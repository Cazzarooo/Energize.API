using Energize.API.Domain.Interfaces.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energize.EnergiaRenovavel.Application.Dto
{
    public class EnergiaRenovavelDto : IEnergiaRenovavelDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public void Validation()
        {
            //FluentValidation

            var validateResult = new EnergiaRenovavelDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(e => e.ErrorMessage)));
        }
    }
    internal class EnergiaRenovavelDtoValidation : AbstractValidator<EnergiaRenovavelDto>
    {
        public EnergiaRenovavelDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Nome)} deve ter no mínimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} não pode ser vazio");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Descricao)} não pode ser vazio");

        }
    }
}
