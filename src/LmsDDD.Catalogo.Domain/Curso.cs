using LmsDDD.Core.DomainObjects;
using System;

namespace LmsDDD.Catalogo.Domain
{
    public class Curso : Entity, IAggregateRoot
    {
        #region Propriedades 
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public Guid CategoriaId { get; private set; }
        public CargaHoraria CargaHoraria { get; private set; }
        public Decimal MediaAprovacao { get; private set; }
        public CursoStatus CursoStatus { get; private set; }
        public Guid? AvaliacaoId { get; private set; }
        public Categoria Categoria { get; private set; }

        #endregion

        #region Construtores
        public Curso(string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, Guid categoriaId, CargaHoraria cargaHoraria)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;
            CargaHoraria = cargaHoraria;
            CursoStatus = CursoStatus.EmDesenvolvimento;

            Validar();
        }
        //EF
        protected Curso() { }

        #endregion

        #region AdHocSetter
        //AdHocSetters -> alterar valores atraves de funcoes por isso private no setter
        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(String descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "O campo descricao do Curso não pode ser vazio.");
            Descricao = descricao;
        }

        public void AlterarValor(decimal valor)
        {
            Validacoes.ValidarSeMenorIgualQue(valor, 0,"O campo valor do Curso não pode menor ou igual a zero.");
            Valor = valor;
        }

        public void AlterarMediaAprovacao(decimal mediaAprovacao)
        {
            Validacoes.ValidarSeMenorIgualQue(mediaAprovacao, 0, "O campo MediaAprovação do Curso não pode menor ou igual a zero.");
            MediaAprovacao = mediaAprovacao;
        }

        public void AssociarAvaliacao(Guid avaliacaoId)
        {
            AvaliacaoId = avaliacaoId;
        }

        public void IndisponibilizarCurso()
        {
            CursoStatus = CursoStatus.InDisponivel;

        }

        public void DisponibilizarCurso()
        {
            CursoStatus = CursoStatus.Disponivel;
        }

        public void RevisarCurso()
        {
            CursoStatus = CursoStatus.EmRevisao;
        }

        #endregion

        #region Validação
        //garantir que o curso para garantir o curso se esta consistente ou nao, dica de boa pratica

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do Curso não pode estar vazio!");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do Curso não pode estar vazio!");
            Validacoes.ValidarSeDiferente(CategoriaId, Guid.Empty, "O campo CategoriaId do Curso não pode estar vazio!");
            Validacoes.ValidarSeMenorIgualQue(Valor, 0, "O valor do Curso não pode ser menor ou igual a zero");
            Validacoes.ValidarSeMenorIgualQue(MediaAprovacao, 0, "A MediaAprovacao do Curso não pode ser menor ou igual a zero");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do Curso não pode estar vazio!");


        }

        #endregion

    }

}
