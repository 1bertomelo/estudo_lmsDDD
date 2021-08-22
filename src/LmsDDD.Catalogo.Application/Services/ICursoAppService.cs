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
        Task<CursoViewModel> EnviarParaRevisaoCurso(Guid id);
        Task<CursoViewModel> RevisarCurso(Guid id);
        Task<CursoViewModel> EnviarParaAprovarRevisao(Guid id);
        Task<CursoViewModel> DisponibilizarCurso(Guid id);
        Task<CursoViewModel> IndisponibilizarCurso(Guid id);

    }
}
