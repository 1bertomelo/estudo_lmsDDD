using System;
using System.Threading.Tasks;

namespace LmsDDD.Cadastros.Domain.Service
{
    public interface IAutenticacaoService : IDisposable
    {
        Task<bool> AutenticarUsuario(string usuario, string senha);
        Task<bool> AlterarSenha(string usuario, string senhaAtual, string novaSenha);

    }
}
