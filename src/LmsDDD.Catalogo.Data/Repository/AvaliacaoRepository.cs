using LmsDDD.Catalogo.Domain;
using LmsDDD.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LmsDDD.Catalogo.Data.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly CatalogoContext _context;

        public AvaliacaoRepository(CatalogoContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;
       
        #region Avaliacao
        public async Task<Avaliacao> ObterPorId(Guid id)
        {
            return await _context.Avaliacoes.FindAsync(id);
        }

        public void Adicionar(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
        }

        public void Atualizar(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Update(avaliacao);
        }


        #endregion

        #region Questao
        public async Task<IEnumerable<Questao>> ObterQuestoesPorAvaliacao(Guid avaliacaoId)
        {
            return await _context.Questoes.AsNoTracking().Where(p => p.AvaliacaoId == avaliacaoId).ToListAsync();
        }

        public void AdicionarQuestao(Questao questao)
        {
            _context.Questoes.Add(questao);
        }

        public void AtualizarQuestao(Questao questao)
        {
            _context.Questoes.Update(questao);
        }
        public async Task<Questao> ObterQuestaoPorId(Guid id)
        {
            return await _context.Questoes.FindAsync(id);
        }

        public void RemoverQuestao(Questao questao)
        {
            _context.Questoes.Remove(questao);
        }


        #endregion

        #region Opcao
        public async Task<Opcao> ObterOpcaoPorId(Guid id)
        {
            return await _context.Opcoes.FindAsync(id);
        }


        public async Task<IEnumerable<Opcao>> ObterOpcoesPorQuestao(Guid questaoId)
        {
            return await _context.Opcoes.AsNoTracking().Where(p => p.QuestaoId == questaoId).ToListAsync();

        }

        public void AdicionarQuestaoOpcao(Opcao opcao)
        {
            _context.Opcoes.Add(opcao);
        }

        public void AtualizarQuestaoOpcao(Opcao opcao)
        {
            _context.Opcoes.Update(opcao);
        }
        public void RemoverQuestaoOpcao(Opcao opcao)
        {
            _context.Opcoes.Remove(opcao);
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
