using LmsDDD.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Domain
{
    public interface IAvaliacaoRepository : IRepository<Avaliacao>
    {
        Task<Avaliacao> ObterPorId(Guid id);
        void Adicionar(Avaliacao avaliacao);
        void Atualizar(Avaliacao avaliacao);

        Task<IEnumerable<Questao>> ObterQuestoesPorAvaliacao(Guid AvaliacaoId);
        Task<Questao> ObterQuestaoPorId(Guid Id);
        void AdicionarQuestao(Questao questao);
        void AtualizarQuestao(Questao questao);
        void RemoverQuestao(Questao questao);

        Task<IEnumerable<Questao>> ObterOpcoesPorQuestao(Guid QuestaoId);
        void AdicionarQuestaoOpcao(Opcao opcao);
        void AtualizarQuestaoOpcao(Opcao opcao);
        void RemoverQuestaoOpcao(Opcao opcao);


    }
}
