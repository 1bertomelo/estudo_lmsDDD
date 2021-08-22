using LmsDDD.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Application.Services
{
    public interface ICursoAppService : IDisposable
    {
        Task<IEnumerable<CursoViewModel>> ObterPorCategoria(int codigo);
        Task<CursoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<CursoViewModel>> ObterTodos();
        Task<IEnumerable<CategoriaViewModel>> ObterCategorias();
        Task AdicionarCurso(CursoViewModel cursoViewModel);
        Task AtualizarCurso(CursoViewModel cursoViewModel);
        Task<bool> EnviarParaRevisaoCurso(Guid id);
        Task<bool> RevisarCurso(Guid id);
        Task<bool> EnviarParaAprovarRevisao(Guid id);
        Task<bool> DisponibilizarCurso(Guid id);
        Task<bool> IndisponibilizarCurso(Guid id);

    }
}
