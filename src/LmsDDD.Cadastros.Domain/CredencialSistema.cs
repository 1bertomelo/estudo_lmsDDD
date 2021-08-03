using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Cadastros.Domain
{
    public class CredencialSistema
    {
        #region Propriedades

        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public bool AlteraSenhaProximoLogin { get; private set; }
        public int QtdeErrosLogin { get; private set; }
        public DateTime? UltimoAcesso { get; private set; }
        public bool LoginBloqueado { get; private set; }

        #endregion

        #region Construtores
        protected CredencialSistema()
        {

        }

        public CredencialSistema(string usuario, string senha, bool alteraSenhaProximoLogin, int qtdeErrosLogin)
        {
            Usuario = usuario;
            Senha = senha;
            AlteraSenhaProximoLogin = alteraSenhaProximoLogin ;
            QtdeErrosLogin = qtdeErrosLogin;
        }

        #endregion

        #region Validação
        //garantir que o curso para garantir o curso se esta consistente ou nao, dica de boa pratica

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Usuario, "O campo Usuario do Colaborador não pode estar vazio!");
            Validacoes.ValidarSeVazio(Senha, "O campo Senha do Colaborador não pode estar vazio!");
            Validacoes.ValidarSeMenorIgualQue(QtdeErrosLogin, 0, "O campo QtdeErrosLogin do Colaborador não pode ser menor igual a zero");
        }

        #endregion
    }
}
