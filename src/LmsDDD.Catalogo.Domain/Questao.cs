using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace LmsDDD.Catalogo.Domain
{
    public class Questao : Entity
    {
        #region Propriedades
        public int Numero { get; private set; }
        public string Enunciado { get; private set; }
        public bool Ativo { get; private set; }
        public Guid AvaliacaoId { get; private set; }
        public DateTime DataCadastro { get; private set; }

        private readonly List<Opcao> _opcoes;

        public IReadOnlyCollection<Opcao> Opcoes => _opcoes;

        //Relacionamento EF
        public Avaliacao Avaliacao { get; set; }
        #endregion

        #region Construtores
        public Questao(int numero, string enunciado, bool ativo, DateTime dataCadastro, Guid avaliacaoId)
        {
            Numero = numero;
            Enunciado = enunciado;
            Ativo = ativo;
            DataCadastro = dataCadastro;
            AvaliacaoId = avaliacaoId;
            _opcoes = new List<Opcao>();
            Validar();
        }

        //EF
        protected Questao(){}
        #endregion

        #region AdHocSetters 
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        internal void AdicionarOpcao(Opcao opcao)
        {
            _opcoes.Add(opcao);
        }

        internal void RemoverOpcao(Opcao opcao)
        {
            _opcoes.Remove(opcao);
        }

        internal void AssociarAvaliacao(Guid avaliacaoId)
        {
            AvaliacaoId = avaliacaoId;
        }

        internal Opcao ObterOpcaoPorId(Guid opcaoID)
        {
           return _opcoes.Find(o => o.Id == opcaoID);
        }

        public int QuantidadeTotalOpcoes()
        {
            return _opcoes.Count;
        }

        #endregion

        #region Validações 
        public void Validar()
        {
            Validacoes.ValidarSeVazio(Enunciado, "O campo Enunciado da Questao não pode estar vazio.");
            Validacoes.ValidarSeIgual(Numero, 0, "O campo , não pode ser zero.");
        }


        #endregion


    }
}
