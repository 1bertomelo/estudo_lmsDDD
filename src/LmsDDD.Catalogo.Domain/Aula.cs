using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Domain
{
    public class Aula : Entity
    {
        #region Propriedades
        public string Nome { get; private set; }
        public CargaHoraria CargaHoraria { get; private set; }
        public string LinkVideo { get; private set; }
        public Guid ModuloId { get; private set; }
        public bool Ativo { get; private set; }
        public Modulo Modulo { get; private set; }
        public string Icone { get; private set; }

        #endregion

        #region Construtores

        protected Aula()
        {

        }

        public Aula(string nome, CargaHoraria cargaHoraria, string linkVideo, Guid moduloId, bool ativo, string icone)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            LinkVideo = linkVideo;
            ModuloId = moduloId;
            Ativo = ativo;
            Icone = icone;
            Validar();
        }

        #endregion

        #region Métodos e funções
        internal void Ativar() => Ativo = true;
        internal void Desativar() => Ativo = false;

        internal void AlterarLinkVideo(string linkVideo)
        {
            LinkVideo = linkVideo;
        }
        #endregion

        #region Validações
        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Enunciado da Nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(LinkVideo, "O campo LinkVideo não pode estar vazio.");
            Validacoes.ValidarSeVazio(Icone, "O campo Icone não pode estar vazio.");
            Validacoes.ValidarSeDiferente(ModuloId, Guid.Empty, "O campo ModuloId da aula não pode estar vazia!");
        }


        #endregion
    }
}
