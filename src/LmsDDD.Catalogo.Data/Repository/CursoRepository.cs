using LmsDDD.Catalogo.Domain;
using LmsDDD.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Data.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CatalogoContext _context;

        public CursoRepository(CatalogoContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;


        #region Cursos
        public async Task<IEnumerable<Curso>> ObterPorCategoria(int codigo)
        {
            return await _context.Cursos.AsNoTracking().ToListAsync();
        }

        public async Task<Curso> ObterPorId(Guid id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task<IEnumerable<Curso>> ObterTodos()
        {
            return await _context.Cursos.AsNoTracking().ToListAsync();
        }

        public void Adicionar(Curso curso)
        {
            _context.Cursos.Add(curso);
        }

        public void Atualizar(Curso curso)
        {
            _context.Cursos.Update(curso);
        }

        #endregion

        #region Categoria 
        public void Adicionar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _context?.Dispose();
        }

        #endregion


    }
}
