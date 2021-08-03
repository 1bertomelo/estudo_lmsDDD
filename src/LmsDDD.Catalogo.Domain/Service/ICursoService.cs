using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Domain.Service
{
    public interface ICursoService : IDisposable
    {
        Task<bool> DisponibilizarCurso(Guid CursoId);
        Task<bool> IndisponibilizarCurso(Guid CursoId);
        Task<bool> RevisarCurso(Guid CursoId);
    }
}
