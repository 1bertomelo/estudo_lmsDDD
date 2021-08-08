using LmsDDD.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Domain
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<IEnumerable<Curso>> ObterTodos();

        Task<Curso> ObterPorId(Guid id);

        Task<IEnumerable<Curso>> ObterPorCategoria(int codigo);
        Task<IEnumerable<Categoria>> ObterCategorias();
        void Adicionar(Curso curso);
        void Atualizar(Curso curso);
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);

    }
}
