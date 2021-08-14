using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Domain.Events
{
    public class CursoEnviarParaRevisaoEvent : DomainEvent
    {
        public string NomeCurso { get; private set; }
        public CursoEnviarParaRevisaoEvent(Guid aggregateId, string nomeCurso) : base(aggregateId)
        {
            NomeCurso = nomeCurso;
        }
    }
}
