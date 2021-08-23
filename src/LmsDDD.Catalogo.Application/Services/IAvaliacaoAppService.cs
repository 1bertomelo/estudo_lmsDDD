using LmsDDD.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Application.Services
{
    public interface IAvaliacaoAppService : IDisposable
    {
        Task<AvaliacaoViewModel> ObterPorId(Guid id);
        Task Adicionar(AvaliacaoViewModel avaliacaoViewModel);
        Task Atualizar(AvaliacaoViewModel avaliacaoViewModel);

        Task<IEnumerable<QuestaoViewmodel>> ObterQuestoesPorAvaliacao(Guid AvaliacaoId);
        Task<QuestaoViewmodel> ObterQuestaoPorId(Guid Id);
        Task AdicionarQuestao(QuestaoViewmodel questaoViewModel);
        Task AtualizarQuestao(QuestaoViewmodel questaoViewModel);
        Task RemoverQuestao(QuestaoViewmodel questaoViewModel);

        Task<IEnumerable<OpcaoViewModel>> ObterOpcoesPorQuestao(Guid QuestaoId);
        Task AdicionarQuestaoOpcao(OpcaoViewModel opcaoViewModel);
        Task AtualizarQuestaoOpcao(OpcaoViewModel opcaoViewModel);
        Task RemoverQuestaoOpcao(OpcaoViewModel opcaoViewModel);

    }
}
