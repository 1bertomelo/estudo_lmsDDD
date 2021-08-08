using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LmsDDD.Infrastructure.Components.Email
{
    public interface IEmailService 
    {

        Task Enviar(Mensagem mensagem);      
        
    }
}
