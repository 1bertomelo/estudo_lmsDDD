using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Cadastros.Domain
{
    public class Colaborador : Entity , IAggregateRoot
    {
        #region Propriedades
        public string Nome { get; private set; }
        public Cpf Cpf { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public DateTime? DataDemissao { get; private set; }
        public Guid CargoId { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Cargo Cargo { get; private set; }
        public Empresa Empresa { get; private set; }
        public Guid? CredencialSistemaId { get; private set; }

        public CredencialSistema CredencialSistema { get; private set; }
        #endregion

        #region construtores
        protected Colaborador()
        {

        }

        public Colaborador(string nome, Cpf cpf, DateTime dataCadastro, bool ativo, DateTime dataAdmissao,  Guid cargoId, Guid empresaId, CredencialSistema credencialSistema)
        {
            Nome = nome;
            Cpf = cpf;
            DataCadastro = dataCadastro;
            Ativo = ativo;
            DataAdmissao = dataAdmissao;
            CargoId = cargoId;
            EmpresaId = empresaId;
            CredencialSistema = credencialSistema;
        }

        #endregion

        #region métodos / funções

        public void AlterarDataAdmissao(DateTime dataAdmissao)
        {
            DataAdmissao = dataAdmissao;
        }

        public void AlterarDataDemissao(DateTime dataDemissao)
        {
            DataDemissao = dataDemissao;
        }

        public void AlterarNome(String nome)
        {
            Validacoes.ValidarSeVazio(nome, "O campo nome do Colarador não pode ser vazio.");
            Nome = nome;
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCargo(Cargo cargo)
        {
            Cargo = cargo;
            CargoId = cargo.Id;
        }

        public void AtribuirCredencialSistema(Guid credencialSistemaId)
        {
            CredencialSistemaId = credencialSistemaId;
        }

        #endregion

        #region Validação
        //garantir que o curso para garantir o curso se esta consistente ou nao, dica de boa pratica

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do Colaborador não pode estar vazio!");
            Validacoes.ValidarSeDiferente(EmpresaId, Guid.Empty, "O campo EmpresaId do Colaborador não pode estar vazio!");
            Validacoes.ValidarSeDiferente(CargoId, Guid.Empty, "O campo CargoId do Colaborador não pode estar vazio!");
        }

        #endregion
    }
}
