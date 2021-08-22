using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Autenticacao.Domain.Service
{
    public interface IAutenticacaoService : IDisposable
    {
        Task<bool> AutenticarUsuario(string usuario, string senha);
        Task<bool> AlterarSenha(string usuario, string senhaAtual, string novaSenha);

    }
}
