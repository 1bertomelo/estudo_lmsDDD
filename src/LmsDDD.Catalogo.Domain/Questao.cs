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
        ICollection<Opcao> Opcoes { get; set; }
        #endregion

        #region Construtores
        public Questao(int numero, string enunciado, bool ativo, DateTime dataCadastro)
        {
            Numero = numero;
            Enunciado = enunciado;
            Ativo = ativo;
            DataCadastro = dataCadastro;
            Validar();
        }

        //EF
        protected Questao(){}
        #endregion

        #region AdHocSetters 
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        internal void AssociarAvaliacao(Guid avaliacaoId)
        {
            AvaliacaoId = avaliacaoId;
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
