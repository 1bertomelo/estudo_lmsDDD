using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Domain.Events
{
    public class CursoIndisponibilizadoEvent : DomainEvent
    {
        public string NomeCurso { get; private set; }

        public CursoIndisponibilizadoEvent(Guid aggregateId, string nomeCurso) : base(aggregateId)
        {
            NomeCurso = nomeCurso;
        }
    }
}
