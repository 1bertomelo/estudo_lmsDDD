using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Cadastros.Domain
{
    public class CredencialSistema : Entity, IAggregateRoot
    {
        #region Propriedades
        private const int NumeroMaximoTentativas = 5;

        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public bool AlteraSenhaProximoLogin { get; private set; }
        public int QtdeTentativasLogin { get; private set; }
        public DateTime? UltimoAcesso { get; private set; }
        public bool LoginBloqueado { get; private set; }

        #endregion

        #region Construtores
        protected CredencialSistema()
        {

        }

        public CredencialSistema(string usuario, string senha, bool alteraSenhaProximoLogin, int qtdeTentativasLogin)
        {
            Usuario = usuario;
            Senha = senha;
            AlteraSenhaProximoLogin = alteraSenhaProximoLogin ;
            QtdeTentativasLogin = qtdeTentativasLogin;
        }

        #endregion

        #region métodos e funções

        public void Bloquear() => LoginBloqueado = true;

        public void Desbloquear() => LoginBloqueado = false;

        public void AdicionarQtdeTentativasLogin()
        {
            QtdeTentativasLogin++;
            if( QtdeTentativasLogin == NumeroMaximoTentativas)
            {
                Bloquear();
            }
        }

        public bool VerificarSenha(string senha)
        {
            if (Senha == senha) return true;

            AdicionarQtdeTentativasLogin();

            return false;
        }

        public void ZerarQtdeTentativasLogin()
        {
            QtdeTentativasLogin = 0;            
        }

        public void AlterarSenha(string novaSenha)
        {
            ValidarSenha();
            Senha = novaSenha;
        }

        public void AlterarDataUltimoAcesso()
        {
            UltimoAcesso = DateTime.Now;
        }

        public void AlterarDataUltimoAcesso(DateTime ultimoAcesso)
        {
            UltimoAcesso = ultimoAcesso;
        }
        #endregion

        #region Validação
        //garantir que o curso para garantir o curso se esta consistente ou nao, dica de boa pratica

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Usuario, "O campo Usuario do Colaborador não pode estar vazio!");
            Validacoes.ValidarSeMenorIgualQue(QtdeTentativasLogin, 0, "O campo QtdeTentativasLogin do Colaborador não pode ser menor igual a zero");
            ValidarSenha();
        }

        private void ValidarSenha()
        {
            Validacoes.ValidarSeVazio(Senha, "O campo Valor da Senha não pode estar vazio!");
            Validacoes.ValidarTamanho(Senha, 8, 15, "O campo Valor da Senha no mínimo tamanho 8 e máximo 15!");
            Validacoes.ValidarQuantidadeMinimaCaracteresEspeciais(Senha, 1, "A senha deve conter no mínimo 1 caractere especial");
            Validacoes.ValidarQuantidadeMinimaLetrasMaiusculas(Senha, 1, "A senha deve conter no mínimo uma letra maiúscula");
            Validacoes.ValidarQuantidadeMinimaNumeros(Senha, 1, "A senha deve conter no mínimo 1 número");
        }

        #endregion
    }
}
