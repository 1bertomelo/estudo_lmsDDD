using LmsDDD.Catalogo.Domain.Events;
using LmsDDD.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Domain.Service
{
    public class ConstrucaoCursoService : IConstrucaoCursoService
    {
        private readonly ICursoRepository _cursoRepository;

        private readonly IMediatrHandler _bus;

        public ConstrucaoCursoService(ICursoRepository cursoRepository, IMediatrHandler bus)
        {
            _cursoRepository = cursoRepository;
            _bus = bus;
        }

        public async Task<bool> EnviarParaRevisaoCurso(Guid CursoId)
        {
            var curso = await _cursoRepository.ObterPorId(CursoId);

            if (curso == null) return false;

            if (curso.AvaliacaoId == null) return false;
            //so posso revisar curso cujo status atual é "Em desenvolvimento"
            //TODO: incluir regra de reprovada revisao 
            if (curso.CursoStatus != CursoStatus.EmDesenvolvimento) return false;

            curso.EnviarParaRevisaoCurso();

            _cursoRepository.Atualizar(curso);

            await _bus.PublicarEvento(new CursoEnviarParaRevisaoEvent(curso.Id, curso.Nome));

            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> RevisarCurso(Guid CursoId)
        {
            var curso = await _cursoRepository.ObterPorId(CursoId);

            if (curso == null) return false;

            if (curso.CursoStatus == CursoStatus.EmRevisao) return false;

            if (curso.AvaliacaoId == null) return false;
            //so posso revisar curso cujo status atual é "Para Revisao"
            if (curso.CursoStatus != CursoStatus.ParaRevisao) return false;

            curso.RevisarCurso();

            _cursoRepository.Atualizar(curso);

            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> EnviarParaAprovarRevisao(Guid CursoId)
        {
            var curso = await _cursoRepository.ObterPorId(CursoId);

            if (curso == null) return false;

            if (curso.AvaliacaoId == null) return false;
            //so posso aprovar a revisao do curso cujo status atual é "Em Revisao"
            if (curso.CursoStatus != CursoStatus.EmRevisao) return false;

            curso.EnviarParaAprovacaoRevisao();

            _cursoRepository.Atualizar(curso);

            await _bus.PublicarEvento(new CursoEnviarParaAprovarRevisaoEvent(curso.Id, curso.Nome));

            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> DisponibilizarCurso(Guid CursoId)
        {
            var curso = await _cursoRepository.ObterPorId(CursoId);
            
            if (curso == null) return false;

            if (curso.CursoStatus == CursoStatus.Disponivel) return false;

            if (curso.AvaliacaoId == null) return false;

            curso.DisponibilizarCurso();

            _cursoRepository.Atualizar(curso);

            await _bus.PublicarEvento(new CursoDisponbilizadoEvent(curso.Id, curso.Nome));

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

       
        public void Dispose()
        {
            _cursoRepository.Dispose();
        }

    }
}
