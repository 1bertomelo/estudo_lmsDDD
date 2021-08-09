using LmsDDD.Core.DomainObjects;
using System;

namespace LmsDDD.Catalogo.Domain
{
    public class Opcao : Entity
    {
        #region Propriedades
        public int Numero { get; private set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool Correta { get; set; }
        public DateTime DataCadastro { get; private set; }
        public Guid QuestaoId { get; private set; }
        //Relacionamento EF
        public Questao Questao { get; set; }

        #endregion

        #region Construtores
        public Opcao(int numero, string descricao, bool ativo, bool correta, DateTime dataCadastro, Guid questaoId)
        {
            Numero = numero;
            Descricao = descricao;
            Ativo = ativo;
            Correta = correta;
            DataCadastro = dataCadastro;
            QuestaoId = questaoId;
            Validar();
        }

        //EF
        protected Opcao(){ }
        #endregion

        #region AdHocSetters 
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        #endregion

        #region Validações
        public void Validar()
        {
            Validacoes.ValidarSeVazio(Descricao, "O campo Enunciado da Questao não pode estar vazio.");
            Validacoes.ValidarSeIgual(Numero, 0, "O campo , não pode ser zero.");
        }
        #endregion
    }
}
