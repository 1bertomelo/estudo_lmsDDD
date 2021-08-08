using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Cadastros.Domain
{
    public class Empresa : Entity, IAggregateRoot
    {
        #region Propriedades
        public string Nome { get; private set; }
        public string RazaoSocial { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime? DataEncerramento { get; private set; }
        public string SubDominio { get; private set; }
        #endregion

        #region Construtor
        protected Empresa()
        {

        }

        public Empresa(string nome, string razaoSocial, Cnpj cnpj, DateTime dataCadastro, bool ativo, DateTime? dataEncerramento, string subDominio)
        {
            Nome = nome;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            DataCadastro = dataCadastro;
            Ativo = ativo;
            DataEncerramento = dataEncerramento;
            SubDominio = subDominio;
        }
        #endregion
    }
}
