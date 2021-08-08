using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Infrastructure.Components.Email
{
    public class Mensagem
    {
        #region Propriedades
        public string De { get; private set; }
        public string Para { get; private set; }
        public string Assunto { get; private set; }
        public string CorpoMensagem { get; private set; }
        #endregion

        #region Construtores

        public Mensagem(string de, string para, string assunto, string corpoMensagem )
        {
            De = de;
            Para = para;
            Assunto = assunto;
            CorpoMensagem = corpoMensagem;
            Validar();
        }

        #endregion

        #region validações
        public void Validar()
        {
            Validacoes.ValidarSeVazio(De, "O campo De da Mensagem não pode estar vazio!");
            Validacoes.ValidarSeVazio(Para, "O campo Para da Mensagem pode estar vazio!");
            Validacoes.ValidarSeVazio(Assunto, "O campo Assunto da Mensagem não pode estar vazio!");
            Validacoes.ValidarSeVazio(CorpoMensagem, "O campo CorpoMensagem da Mensagem pode estar vazio!");

        }
        #endregion

    }
}
