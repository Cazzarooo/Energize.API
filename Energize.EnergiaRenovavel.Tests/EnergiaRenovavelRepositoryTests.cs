using Energize.API.Domain.Entities;
using Energize.EnergiaRenovavel.Application.Dto;
using Energize.EnergiaRenovavel.Data.AppData;
using Energize.EnergiaRenovavel.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Energize.EnergiaRenovavel.Tests
{
    public class EnergiaRenovavelRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly EnergiaRenovavelRepository _energiaRenovavelRepository;

        public EnergiaRenovavelRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationContext(_options);
            _energiaRenovavelRepository = new EnergiaRenovavelRepository(_context);
        }

        [Fact]
        public void Adicionar_DeveAdicionarERetornarEnergiaRenovavelEntity()
        {
            // Arrange
            var energiaRenovavel = new EnergiaRenovavelEntity { Nome = "Celular", Descricao = "Preto" };

            // Act
            var resultado = _energiaRenovavelRepository.SalvarDados(energiaRenovavel);

            // Assert
            var energiaRenovavelNoDb = _context.EnergiaRenovavel.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(energiaRenovavelNoDb);
            Assert.Equal(energiaRenovavel.Nome, energiaRenovavelNoDb.Nome);
            Assert.Equal(energiaRenovavel.Descricao, energiaRenovavelNoDb.Descricao);
        }
    }
}
