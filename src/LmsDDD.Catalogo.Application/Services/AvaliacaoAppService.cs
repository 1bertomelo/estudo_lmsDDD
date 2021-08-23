using AutoMapper;
using LmsDDD.Catalogo.Application.ViewModels;
using LmsDDD.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Application.Services
{
    public class AvaliacaoAppService : IAvaliacaoAppService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;      
        private readonly IMapper _mapper;

        public async Task Adicionar(AvaliacaoViewModel avaliacaoViewModel)
        {
            var avaliacao = _mapper.Map<Avaliacao>(avaliacaoViewModel);
            _avaliacaoRepository.Adicionar(avaliacao);

            await _avaliacaoRepository.UnitOfWork.Commit();
        }

        public async Task AdicionarQuestao(QuestaoViewmodel questaoViewmodel)
        {
            var questao = _mapper.Map<Questao>(questaoViewmodel);
            _avaliacaoRepository.AdicionarQuestao(questao);

            await _avaliacaoRepository.UnitOfWork.Commit();
        }

        public async Task AdicionarQuestaoOpcao(OpcaoViewModel opcaoViewModel)
        {
            var opcao = _mapper.Map<Opcao>(opcaoViewModel);
            _avaliacaoRepository.AdicionarQuestaoOpcao(opcao);

            await _avaliacaoRepository.UnitOfWork.Commit();
        }

        public async Task Atualizar(AvaliacaoViewModel avaliacaoViewModel)
        {
            var avaliacao = _mapper.Map<Avaliacao>(avaliacaoViewModel);
            _avaliacaoRepository.Atualizar(avaliacao);

            await _avaliacaoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarQuestao(QuestaoViewmodel questaoViewModel)
        {
            var questao = _mapper.Map<Questao>(questaoViewModel);
            _avaliacaoRepository.AtualizarQuestao(questao);

            await _avaliacaoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarQuestaoOpcao(OpcaoViewModel opcaoViewModel)
        {
            var opcao = _mapper.Map<Opcao>(opcaoViewModel);
            _avaliacaoRepository.AtualizarQuestaoOpcao(opcao);

            await _avaliacaoRepository.UnitOfWork.Commit();
        }


        public async Task<IEnumerable<OpcaoViewModel>> ObterOpcoesPorQuestao(Guid QuestaoId)
        {
            return _mapper.Map<IEnumerable<OpcaoViewModel>>(await _avaliacaoRepository.ObterOpcoesPorQuestao(QuestaoId));
        }

        public async Task<AvaliacaoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<AvaliacaoViewModel>(await _avaliacaoRepository.ObterPorId(id));
        }

        public async Task<QuestaoViewmodel> ObterQuestaoPorId(Guid id)
        {
            return _mapper.Map<QuestaoViewmodel>(await _avaliacaoRepository.ObterQuestaoPorId(id));
        }

        public async Task<IEnumerable<QuestaoViewmodel>> ObterQuestoesPorAvaliacao(Guid avaliacaoId)
        {
            return _mapper.Map<IEnumerable<QuestaoViewmodel>>(await _avaliacaoRepository.ObterQuestoesPorAvaliacao(avaliacaoId));
        }

        public async Task RemoverQuestao(QuestaoViewmodel questaoViewModel)
        {
            var questao = _mapper.Map<Questao>(questaoViewModel);
            _avaliacaoRepository.RemoverQuestao(questao);

            await _avaliacaoRepository.UnitOfWork.Commit();
        }

        public async Task RemoverQuestaoOpcao(OpcaoViewModel opcaoViewModel)
        {
            var opcao = _mapper.Map<Opcao>(opcaoViewModel);
            _avaliacaoRepository.RemoverQuestaoOpcao(opcao);

            await _avaliacaoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
           _avaliacaoRepository?.Dispose();
        }

    }
}
