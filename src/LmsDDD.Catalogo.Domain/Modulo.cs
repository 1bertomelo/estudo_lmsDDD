using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Domain
{
    public class Modulo : Entity, IAggregateRoot
    {
        #region Propriedades

        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public string Icone { get; private set; }
        public Guid CursoId { get; private set; }
        //EF Ref
        public Curso Curso { get; private set; }

        private readonly List<Aula> _aulas;
        public IReadOnlyCollection<Aula> Aulas => _aulas;

        #endregion

        #region Construtores
        protected Modulo()
        {

        }

        public Modulo(string nome, bool ativo, string icone, Guid cursoId)
        {
            Nome = nome;
            Ativo = ativo;
            Icone = icone;
            CursoId = cursoId;
            _aulas = new List<Aula>();
            Validar();
        }


        #endregion

        #region Métodos e funções
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AdicionarAula(Aula aula)
        {
            _aulas.Add(aula);
        }

        public void DesativarAula(Aula aula)
        {
            var aulaExistente = _aulas.Find(a => a.Id == aula.Id);

            if (aulaExistente == null) throw new DomainException("A aula não pertence ao módulo");
                aulaExistente.Desativar();
        }

        public void AtivarAula(Aula aula)
        {
            var aulaExistente = _aulas.Find(a => a.Id == aula.Id);

            if (aulaExistente == null) throw new DomainException("A aula não pertence ao módulo");
                aulaExistente.Ativar();
        }

        public void RemoverAula(Aula aula)
        {          
            var aulaExistente = _aulas.Find(a => a.Id == aula.Id);

            if (aulaExistente == null) throw new DomainException("A aula não pertence ao módulo");
                _aulas.Remove(aulaExistente);
        }

        public void AlterarLinkVideoAula(Aula aula, string linkVideo)
        {
            var aulaExistente = _aulas.Find(a => a.Id == aula.Id);

            if (aulaExistente == null) throw new DomainException("A aula não pertence ao módulo");
                aulaExistente.AlterarLinkVideo(linkVideo);
        }


        public int QuantidadeTotalAulas()
        {
            return _aulas.Count;
        }


        #endregion

        #region Validações
        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Enunciado da Nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(Icone, "O campo Icone não pode estar vazio.");
            Validacoes.ValidarSeDiferente(CursoId, Guid.Empty, "O campo CursoId não pode estar vazia!");
        }

        #endregion
    }
}
