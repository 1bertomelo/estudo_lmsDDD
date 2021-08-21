using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;

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
        //EF Ref
        public ICollection<Modulo> Modulos { get; set; }
        #endregion

        #region Construtores
        public Curso(string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, Guid categoriaId, CargaHoraria cargaHoraria, Decimal mediaAprovacao)
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
            MediaAprovacao = mediaAprovacao;
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
            Validacoes.ValidarSeVazio(descricao, "O campo Descricao do Curso não pode estar vazio!");
            Descricao = descricao;
        }

        public void AlterarValor(decimal valor)
        {
            Validacoes.ValidarSeMenorIgualQue(valor, 0, "O valor do Curso não pode ser menor ou igual a zero");
            Valor = valor;
        }

        public void AlterarMediaAprovacao(decimal mediaAprovacao)
        {
            Validacoes.ValidarSeMenorQue(mediaAprovacao, 0, "A MediaAprovacao do Curso não pode ser menor que zero");
            MediaAprovacao = mediaAprovacao;
        }

        public void AssociarAvaliacao(Guid avaliacaoId)
        {
            AvaliacaoId = avaliacaoId;
        }

        public void IniciarDesenvolvimentoCurso()
        {
            CursoStatus = CursoStatus.EmDesenvolvimento;
        }

        public void EnviarParaRevisaoCurso()
        {
            CursoStatus = CursoStatus.ParaRevisao;
        }
        public void RevisarCurso()
        {
            CursoStatus = CursoStatus.EmRevisao;
        }

        public void EnviarParaAprovacaoRevisao()
        {
            CursoStatus = CursoStatus.AguardandoAprovacaoRevisao;
        }


        public void DisponibilizarCurso()
        {
            CursoStatus = CursoStatus.Disponivel;
        }

        public void IndisponibilizarCurso()
        {
            CursoStatus = CursoStatus.InDisponivel;

        }      
        
        #endregion

        #region Validação
        //garantir que o curso para garantir o curso se esta consistente ou nao, dica de boa pratica

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do Curso não pode estar vazio!");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do Curso não pode estar vazio!");
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo CategoriaId do Curso não pode estar vazio!");
            Validacoes.ValidarSeMenorIgualQue(Valor, 0, "O valor do Curso não pode ser menor ou igual a zero");
            Validacoes.ValidarSeMenorQue(MediaAprovacao, 0, "A MediaAprovacao do Curso não pode ser menor que zero");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do Curso não pode estar vazio!");


        }

        #endregion


        #region Factory
        //por que factory? facilitar a criação de um objeto
        //e principalmente associar a linguagem ubiquoa e dar um sentido
        //mais claro, por exemplo, New Curso(......) nao expressa
        //a intencao da linguagem ubiquoa claramente que é de criar um curso
        public static class CursoFactory
        {
            public static Curso IniciarConstrucaoCurso()
            {
                var curso = new Curso();
                curso.IniciarDesenvolvimentoCurso();
                return curso;
            }
        }

        #endregion
    }

}
