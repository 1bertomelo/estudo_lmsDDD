﻿using LmsDDD.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsDDD.Cadastros.Domain
{
    public interface ICredencialSistemaRepository : IRepository<CredencialSistema>
    {
        Task<CredencialSistema> ObterPorUsuario(string usuario);
        void AlterarSenha(string usuario, string senha);

        void Adicionar(CredencialSistema credencialSistema);

        void Atualizar(CredencialSistema credencialSistema);

    }
}
