using LmsDDD.Catalogo.Domain;
using LmsDDD.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LmsDDD.Catalogo.Data.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        #region Avaliacao
        public Task<Avaliacao> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Avaliacao avaliacao)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Avaliacao avaliacao)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Questao
        public Task<IEnumerable<Questao>> ObterQuestoesPorAvaliacao(Guid AvaliacaoId)
        {
            throw new NotImplementedException();
        }

        public void AdicionarQuestao(Questao questao)
        {
            throw new NotImplementedException();
        }

        public void AtualizarQuestao(Questao questao)
        {
            throw new NotImplementedException();
        }
        public Task<Questao> ObterQuestaoPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void RemoverQuestao(Questao questao)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Opcao

        public Task<IEnumerable<Questao>> ObterOpcoesPorQuestao(Guid QuestaoId)
        {
            throw new NotImplementedException();
        }

        public void AdicionarQuestaoOpcao(Opcao opcao)
        {
            throw new NotImplementedException();
        }

        public void AtualizarQuestaoOpcao(Opcao opcao)
        {
            throw new NotImplementedException();
        }
        public void RemoverQuestaoOpcao(Opcao opcao)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
