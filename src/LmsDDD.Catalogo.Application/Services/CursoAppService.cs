using AutoMapper;
using LmsDDD.Catalogo.Application.ViewModels;
using LmsDDD.Catalogo.Domain;
using LmsDDD.Catalogo.Domain.Service;
using LmsDDD.Core.DomainObjects;
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

        public async Task AdicionarCurso(CursoViewModel cursoViewModel)
        {
            var curso = _mapper.Map<Curso>(cursoViewModel);
            _cursoRepository.Adicionar(curso);

            await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarCurso(CursoViewModel cursoViewModel)
        {
            var curso = _mapper.Map<Curso>(cursoViewModel);
            _cursoRepository.Atualizar(curso);

            await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _cursoRepository.ObterCategorias());
        }

        public async Task<IEnumerable<CursoViewModel>> ObterPorCategoria(int codigo)
        {
            
            return _mapper.Map<IEnumerable<CursoViewModel>>(await _cursoRepository.ObterPorCategoria(codigo));
        }

        public async Task<CursoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<CursoViewModel>(await _cursoRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<CursoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CursoViewModel>>(await _cursoRepository.ObterTodos());
        }

        public async Task<CursoViewModel> RevisarCurso(Guid id)
        {            
            if (!_construcaoCursoService.RevisarCurso(id).Result)
            {
                throw new DomainException("Falha ao mudar status para Revisar Curso");
            }

            return _mapper.Map<CursoViewModel>(await _cursoRepository.ObterPorId(id));
        }

        public async Task<CursoViewModel> DisponibilizarCurso(Guid id)
        {
            if (!_construcaoCursoService.DisponibilizarCurso(id).Result)
            {
                throw new DomainException("Falha ao mudar status para Curso Disponibilizado");
            }

            return _mapper.Map<CursoViewModel>(await _cursoRepository.ObterPorId(id));
        }

        public async Task<CursoViewModel> EnviarParaAprovarRevisao(Guid id)
        {
            if (!_construcaoCursoService.EnviarParaAprovarRevisao(id).Result)
            {
                throw new DomainException("Falha ao mudar status para Aprovar Revisõ Curso");
            }

            return _mapper.Map<CursoViewModel>(await _cursoRepository.ObterPorId(id));
        }

        public async Task<CursoViewModel> EnviarParaRevisaoCurso(Guid id)
        {
            if (!_construcaoCursoService.EnviarParaRevisaoCurso(id).Result)
            {
                throw new DomainException("Falha ao mudar status para Enviar para Revisão Curso");
            }

            return _mapper.Map<CursoViewModel>(await _cursoRepository.ObterPorId(id));
        }

        public async Task<CursoViewModel> IndisponibilizarCurso(Guid id)
        {
            if (!_construcaoCursoService.IndisponibilizarCurso(id).Result)
            {
                throw new DomainException("Falha ao mudar status para Curso Indisponibilizado!");
            }

            return _mapper.Map<CursoViewModel>(await _cursoRepository.ObterPorId(id));
        }



        public void Dispose()
        {
            _cursoRepository?.Dispose();
            _construcaoCursoService?.Dispose();
        }

    }
}
