using LmsDDD.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Cadastros.Domain
{
    public interface IColaboradorRepository : IRepository<Colaborador>
    {
        Task<IEnumerable<Colaborador>> ObterTodos();
        Task<Colaborador> ObterPorId(Guid id);
        void Adicionar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void Remover(Guid colaboradorId);
    }
}
