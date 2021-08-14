using LmsDDD.Infrastructure.Components.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LmsDDD.Catalogo.Domain.Events
{
    public class CursoEventHandler : INotificationHandler<CursoDisponbilizadoEvent>
    {
        private readonly IEmailService _emailService;

        #region construtor
        public CursoEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        #endregion

        #region Handles

        public async Task Handle(CursoDisponbilizadoEvent message, CancellationToken cancellationToken)
        { 
            //Mandar um email por exemplo   
            await _emailService.Enviar(
                new Mensagem("de@gmail",
                             "para@gmail",
                             $"Disponibilização Curso: {message.NomeCurso}",
                             $"Cadastro do curso {message.NomeCurso} foi finalizado e revisado com sucesso. " +
                             $"Curso está disponível para ser liberado para os alunos!"
                             )
                );
        }


        public async Task Handle(CursoEnviarParaRevisaoEvent message, CancellationToken cancellationToken)
        {
            await _emailService.Enviar(
               new Mensagem("de@gmail",
                            "para@gmail",
                            $"Revisão Curso: {message.NomeCurso}",
                            $"O curso {message.NomeCurso} foi enviado para revisão. " +
                            $"O setor de redação deve revisar o conteúdo do curso"
                            )
               );
        }


        public async Task Handle(CursoIndisponibilizadoEvent message, CancellationToken cancellationToken)
        {
            await _emailService.Enviar(
               new Mensagem("de@gmail",
                            "para@gmail",
                            $"Indisponibilização Curso: {message.NomeCurso}",
                            $"O curso {message.NomeCurso} foi indisponibilizado para os alunos " +
                            $" em {message.Timestamp}"

                           )
               ); 
        }

        public async Task Handle(CursoEnviarParaAprovarRevisaoEvent message, CancellationToken cancellationToken)
        {
            await _emailService.Enviar(
               new Mensagem("de@gmail",
                            "para@gmail",
                            $"Aprovar Revisão Curso: {message.NomeCurso}",
                            $"O curso {message.NomeCurso} está disponível para aprovação da revisão."
                           )
               ) ;
        }
        #endregion
    }
    }
