using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Infrastructure.Components.Email
{
    public class ConfiguracaoEmail
    {
        #region Propriedades

        public string HostServidor { get; private set; }
        public int Porta { get; private set; }
        public bool HabilitaSsl { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }

        public string NomeEmissor { get; private set; }
        #endregion

        #region Construtores
        public ConfiguracaoEmail(string hostServidor, int porta, bool habilitaSsl, string usuario, string senha, string nomeEmissor)
        {
            HostServidor = hostServidor;
            Porta = porta;
            HabilitaSsl = habilitaSsl;
            Usuario = usuario;
            Senha = senha;
            NomeEmissor = nomeEmissor;
        }

        #endregion

        #region validações
        public void Validar()
        {
            Validacoes.ValidarSeVazio(HostServidor, "O campo HostServidor não pode estar vazio!");
            Validacoes.ValidarSeVazio(Usuario, "O Usuario não pode estar vazio!");
            Validacoes.ValidarSeVazio(Senha, "O campo Senha não pode estar vazio!");
            Validacoes.ValidarSeMenorQue(Porta, 1, "O campo Porta não pode ser menor igual a zero!");
            Validacoes.ValidarSeVazio(NomeEmissor, "O campo NomeEmissor não pode estar vazio!");

        }
        #endregion


    }
}
