using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Cadastros.Domain.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly ICredencialSistemaRepository _credencialSistemaRepository;

        public AutenticacaoService(ICredencialSistemaRepository credencialSistemaRepository)
        {
            _credencialSistemaRepository = credencialSistemaRepository;
        }

        public async Task<bool> AlterarSenha(string usuario, string senhaAtual, string novaSenha)
        {
            var usuarioAutenticado = await _credencialSistemaRepository.ObterPorUsuario(usuario);

            if (usuarioAutenticado == null) return false;

            if (usuarioAutenticado.LoginBloqueado) return false;

            if (!usuarioAutenticado.VerificarSenha(novaSenha)) return false;

            usuarioAutenticado.AlterarSenha(novaSenha);

            usuarioAutenticado.ZerarQtdeTentativasLogin();

            _credencialSistemaRepository.AlterarSenha(usuario, novaSenha);
            //mandar email aqui
            return await _credencialSistemaRepository.UnitOfWork.Commit();
        }

        public async Task<bool> AutenticarUsuario(string usuario, string senha)
        {
            var usuarioAutenticado = await _credencialSistemaRepository.ObterPorUsuario(usuario);

            if (usuarioAutenticado == null) return false;

            if (usuarioAutenticado.LoginBloqueado) return false;

            if (!usuarioAutenticado.VerificarSenha(senha)) return false;

            usuarioAutenticado.AlterarDataUltimoAcesso();

            usuarioAutenticado.ZerarQtdeTentativasLogin();

            _credencialSistemaRepository.Atualizar(usuarioAutenticado);

            return await _credencialSistemaRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _credencialSistemaRepository.Dispose();
        }
    }
}
