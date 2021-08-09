using LmsDDD.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Domain
{
    public interface IModuloRepository : IRepository<Modulo>
    {
        Task<IEnumerable<Modulo>> ObterTodos();
        Task<Modulo> ObterPorId(Guid id);
        void Adicionar(Modulo modulo);
        void Atualizar(Modulo modulo);

        Task<IEnumerable<Aula>> ObterTodasAulas(Guid ModuloId);
        Task<Aula> ObterAulaPorId(Guid Id);
        void AdicionarAula(Aula aula);
        void AtualizarAula(Aula aula);
        void RemoverAula(Aula aula);

    }
}
