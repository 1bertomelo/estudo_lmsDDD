using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace LmsDDD.Catalogo.Domain
{
    public class Categoria : Entity
    {

        #region Propriedades
        public int Codigo { get; private set; }
        public string Nome { get; private set; }

        public ICollection<Curso> Cursos {get; set;}
        #endregion

        #region Construtores
        public Categoria(int codigo, string nome)
        {
            Nome = nome;
            Codigo = codigo;
            Validar();
        }
        //EF
        protected Categoria() { }
        #endregion

        #region Sobrecargas
        //Ela e imutavel ou seja nao consegue mudar depois de construida, ou seja, sem AdHocSetter
        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }
        #endregion

        #region Validações

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome da categoria não pode estar vazio.");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo código não pode ser zero.");
        }

        #endregion

    }
}
