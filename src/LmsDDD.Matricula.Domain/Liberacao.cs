using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace LmsDDD.Matricula.Domain
{
    public class Liberacao : Entity, IAggregateRoot
    {
        #region Propriedades
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataInicio   { get; private set; }
        public DateTime? DataFim { get; private set; }
        public int PrazoExecucaoDias { get; private set; }

        private readonly List<LiberacaoItemCurso> _cursos;
        public IReadOnlyCollection<LiberacaoItemCurso> Cursos => _cursos;
        #endregion

        #region Construtores
        //EF
        protected  Liberacao()
        {

        }

        #endregion

        #region Métodos e funções

        #endregion

        #region Validações

        #endregion
    }
}
