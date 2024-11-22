using Energize.API.Domain.Entities;
using Energize.API.Domain.Interfaces;
using Energize.API.Domain.Interfaces.Dtos;
using Energize.EnergiaRenovavel.Application.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Energize.EnergiaRenovavel.Tests
{
    public class EnergiaRenovavelApplicationServiceTests
    {
        private readonly Mock<IEnderecoService> _enderecoServiceMock;
        private readonly Mock<IEnergiaRenovavelRepository> _repositoryMock;
        private readonly EnergiaRenovavelApplicationService _energiaRenovavelService;

        public EnergiaRenovavelApplicationServiceTests()
        {
            _repositoryMock = new Mock<IEnergiaRenovavelRepository>();
            _enderecoServiceMock = new Mock<IEnderecoService>();
            _energiaRenovavelService = new EnergiaRenovavelApplicationService(_repositoryMock.Object, _enderecoServiceMock.Object);
        }

        [Fact]
        public void AdicionarEnergiaRenovavel_DeveRetornarEnergiaRenovavelEntity_QuandoAdicionarComSucesso()
        {
            // Arrange
            var energiaRenovavelDtoMock = new Mock<IEnergiaRenovavelDto>();
            energiaRenovavelDtoMock.Setup(c => c.Nome).Returns("Fernanda");
            energiaRenovavelDtoMock.Setup(c => c.Descricao).Returns("Solar");


            var energiaRenovavelEsperado = new EnergiaRenovavelEntity { Nome = "Fernanda", Descricao = "Solar" };

            _repositoryMock.Setup(r => r.SalvarDados(It.IsAny<EnergiaRenovavelEntity>())).Returns(energiaRenovavelEsperado);

            // Act
            var resultado = _energiaRenovavelService.SalvarDadosEnergiaRenovavel(energiaRenovavelDtoMock.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(energiaRenovavelEsperado.Nome, resultado.Nome);
            Assert.Equal(energiaRenovavelEsperado.Descricao, resultado.Descricao);

        }
    }
}
