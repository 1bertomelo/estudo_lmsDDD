using LmsDDD.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Cadastros.Domain
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<IEnumerable<Empresa>> ObterTodas();
        Task<Empresa> ObterPorId(Guid id);
        void Adicionar(Empresa empresa);
        void Atualizar(Empresa empresa);
        void Remover(Guid empresaId);

    }
}
