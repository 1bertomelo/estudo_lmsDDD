using LmsDDD.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Domain
{
    public interface IModuloRepository : IRepository<Modulo>
    {
        Task<Avaliacao> ObterPorId(Guid id);
        void Adicionar(Modulo modulo);
        void Atualizar(Modulo modulo);

        Task<Questao> ObterAulaPorId(Guid Id);
        void AdicionarAula(Aula aula);
        void AtualizarAula(Aula aula);
        void RemoverAula(Aula aula);

    }
}
