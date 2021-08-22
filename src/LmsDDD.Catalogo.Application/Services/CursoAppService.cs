using AutoMapper;
using LmsDDD.Catalogo.Application.ViewModels;
using LmsDDD.Catalogo.Domain;
using LmsDDD.Catalogo.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Application.Services
{
    public class CursoAppService : ICursoAppService
    {

        private readonly ICursoRepository _cursoRepository;
        private readonly IConstrucaoCursoService _construcaoCursoService;
        private readonly IMapper _mapper;

        public CursoAppService(ICursoRepository cursoRepository, IConstrucaoCursoService construcaoCursoService, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _construcaoCursoService = construcaoCursoService;
            _mapper = mapper;
        }

        public Task AdicionarCurso(CursoViewModel cursoViewModel)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarCurso(CursoViewModel cursoViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DisponibilizarCurso(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnviarParaAprovarRevisao(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnviarParaRevisaoCurso(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IndisponibilizarCurso(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CursoViewModel>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<CursoViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CursoViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RevisarCurso(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
