using LmsDDD.Catalogo.Domain;
using LmsDDD.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Data.Repository
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly CatalogoContext _context;

        public ModuloRepository(CatalogoContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        #region Modulo
        public Task<IEnumerable<Modulo>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<Modulo> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Modulo modulo)
        {
            throw new NotImplementedException();
        }
        public void Atualizar(Modulo modulo)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Aula
        public void AdicionarAula(Aula aula)
        {
            throw new NotImplementedException();
        }


        public void AtualizarAula(Aula aula)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aula>> ObterTodasAulas(Guid ModuloId)
        {
            throw new NotImplementedException();
        }

        Task<Aula> IModuloRepository.ObterAulaPorId(Guid Id)
        {
            throw new NotImplementedException();
        }


        public void RemoverAula(Aula aula)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
            throw new NotImplementedException();
        }



        #endregion


    }
}
