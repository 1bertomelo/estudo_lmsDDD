using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Domain.Events
{
    public class CursoEnviarParaAprovarRevisaoEvent : DomainEvent
    {
        public string NomeCurso { get; private set; }

        public CursoEnviarParaAprovarRevisaoEvent(Guid aggregateId, string nomeCurso) : base(aggregateId)
        {
            NomeCurso = nomeCurso;
        }
    }
}
