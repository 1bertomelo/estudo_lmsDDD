using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Domain.Service
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<bool> DisponibilizarCurso(Guid CursoId)
        {
            var curso = await _cursoRepository.ObterPorId(CursoId);
            
            if (curso == null) return false;

            if (curso.CursoStatus == CursoStatus.Disponivel) return false;

            if (curso.AvaliacaoId == null) return false;

            curso.DisponibilizarCurso();

            _cursoRepository.Atualizar(curso);
            
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> IndisponibilizarCurso(Guid CursoId)
        {
            var curso = await _cursoRepository.ObterPorId(CursoId);

            if (curso == null) return false;

            if (curso.CursoStatus == CursoStatus.InDisponivel) return false;

            curso.IndisponibilizarCurso();

            _cursoRepository.Atualizar(curso);

            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> RevisarCurso(Guid CursoId)
        {
            var curso = await _cursoRepository.ObterPorId(CursoId);

            if (curso == null) return false;

            if (curso.CursoStatus == CursoStatus.EmRevisao) return false;

            if (curso.AvaliacaoId == null) return false;

            curso.RevisarCurso();

            _cursoRepository.Atualizar(curso);

            return await _cursoRepository.UnitOfWork.Commit();
        }


        public void Dispose()
        {
            _cursoRepository.Dispose();
        }

    }
}
