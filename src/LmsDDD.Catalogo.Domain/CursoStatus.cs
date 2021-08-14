using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Domain
{
    public enum CursoStatus
    {   //colocado de 10 em 10 pra facilicar caso surge algum status
        //intermediario e alocar na mesma ordem lógica

        EmDesenvolvimento = 10,
        ParaRevisao = 20,
        EmRevisao  = 30,
        AguardandoAprovacaoRevisao = 40,
        Disponivel = 50,
        InDisponivel = 60

        //fluxo construção de um curso
        //Criar curso -> em desenvolvimento
        //Enviar para revisao ->  ParaRevisao
        //Revisar curso -> EmRevisao
        //EnviarParaAprovarRevisao ->EnviarParaAprovarRevisao
        //DisponibilizarCurso -> disponivel
        //Indisponiblizar o curso  -> InDisponivel
        //TODO: criar depois a reprovacao da revisao
    }
}
