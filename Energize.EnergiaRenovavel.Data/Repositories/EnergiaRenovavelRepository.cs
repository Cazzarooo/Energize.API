using Energize.API.Domain.Entities;
using Energize.API.Domain.Interfaces;
using Energize.EnergiaRenovavel.Data.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energize.EnergiaRenovavel.Data.Repositories
{
    public class EnergiaRenovavelRepository : IEnergiaRenovavelRepository
    {
        private readonly ApplicationContext _context;

        public EnergiaRenovavelRepository(ApplicationContext context)
        {
            _context = context;
        }

        public EnergiaRenovavelEntity? DeletarDados(int id)
        {
            var energiaRenovavel = _context.EnergiaRenovavel.Find(id);

            if (energiaRenovavel is not null)
            {
                _context.EnergiaRenovavel.Remove(energiaRenovavel);
                _context.SaveChanges();

                return energiaRenovavel;
            }
            return null;
        }

        public EnergiaRenovavelEntity? EditarDados(EnergiaRenovavelEntity entity)
        {
            var energiaRenovavel = _context.EnergiaRenovavel.Find(entity.Id);

            if (energiaRenovavel is not null)
            {
                energiaRenovavel.Nome = entity.Nome;
                energiaRenovavel.Descricao = entity.Descricao;

                _context.EnergiaRenovavel.Update(energiaRenovavel);
                _context.SaveChanges();

                return energiaRenovavel;
            }
            return null;
        }

        public EnergiaRenovavelEntity? ObterPorId(int id)
        {
            var energiaRenovavel = _context.EnergiaRenovavel.Find(id);

            if (energiaRenovavel is not null)
            {

                return energiaRenovavel;
            }

            return null;
        }

        public IEnumerable<EnergiaRenovavelEntity> ObterTodos()
        {
            var energiaRenovavel = _context.EnergiaRenovavel.ToList();
            return energiaRenovavel;
        }

        public EnergiaRenovavelEntity? SalvarDados(EnergiaRenovavelEntity entity)
        {
            _context.EnergiaRenovavel.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
