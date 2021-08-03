using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Cadastros.Domain
{
    public class Empresa : Entity
    {
        #region Propriedades
        public string Nome { get; private set; }
        public string RazaoSocial { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime? DataEncerramento { get; private set; }

        #endregion

        #region Construtor
        protected Empresa()
        {

        }
        #endregion
    }
}
