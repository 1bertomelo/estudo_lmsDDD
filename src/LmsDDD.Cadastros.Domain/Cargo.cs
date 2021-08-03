using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Cadastros.Domain
{
    public class Cargo : Entity, IAggregateRoot
    {
        #region Propriedades  
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Guid EmpresaId { get; private set; }

        #endregion

        #region Construtores

        public Cargo(string nome, string descricao, bool ativo, DateTime dataCadastro, Guid empresaId)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            DataCadastro = dataCadastro;
            EmpresaId = empresaId;
        }

        protected Cargo()
        {

        }


        #endregion

        #region Validações

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do Cargo não pode estar vazio!");
            Validacoes.ValidarSeDiferente(EmpresaId, Guid.Empty, "O campo EmpresaId do Cargo não pode estar vazio!");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do Cargo não pode estar vazio!");

        }

        #endregion

    }
}
