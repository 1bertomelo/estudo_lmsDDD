using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace LmsDDD.Catalogo.Domain
{
    public class Avaliacao: Entity, IAggregateRoot
    {
        #region Propriedades
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public decimal ValorTotal { get; private set; }
        //lista de questoes utilizada interna pela classe reais
        private readonly List<Questao> _questoes;
        //lista expor externamente e proteger de utilizar o add da lista
        //forçando adicionar questao pelo metodo e manter o controle da raiz de agregação
        public IReadOnlyCollection<Questao> Questoes => _questoes;

        #endregion

        #region Construtores
        //EF
        protected Avaliacao(){}

        public Avaliacao(string nome, bool ativo, DateTime dataCadastro, decimal valorTotal)
        {
            Nome = nome;
            Ativo = ativo;
            DataCadastro = dataCadastro;
            ValorTotal = valorTotal;
            _questoes = new List<Questao>();
            Validar();
        }

        #endregion

        #region AdHoc 
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AdicionarQuestao(Questao questao)
        {
            _questoes.Add(questao);
        }

        public int QuantidadeTotalQuestoes()
        {
            return _questoes.Count;
        }

        #endregion


        #region Validações
        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da Avaliação não pode estar vazio!");
            Validacoes.ValidarSeMenorQue(ValorTotal, 0, "O valor total da avaliação não pode ser menor ou igual a zero");
        }

        #endregion
    }




}
