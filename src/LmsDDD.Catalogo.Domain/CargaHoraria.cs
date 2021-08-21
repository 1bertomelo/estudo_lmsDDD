using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Domain
{
    //Objeto de Valor CargaHoraria
    public class CargaHoraria
    {

        #region Propriedades
        //Essa classe é um ValueObject ou seja um objeto de valor.
        //Deve ser Imutavel
        public int Hora { get; private set; }
        public int Minuto { get; private set; }
        #endregion

        #region Construtores
        public CargaHoraria(int hora, int minuto)
        {
            Hora = hora;
            Minuto = minuto;

            Validar();
        }

        #endregion

        #region Métodos e sobrecargas
                public string CargaHorariaFormatada()
                {
                    string minutoFormatado = Minuto < 10 ? "0" + Minuto.ToString() : Minuto.ToString();
                    string horaFormatada = Hora < 10 ? "0" + Hora.ToString() : Hora.ToString();
                    return $"HH:MM =  {horaFormatada}:{minutoFormatado}";
                }

                public override string ToString()
                {
                    return CargaHorariaFormatada();
                }

        #endregion

        #region Validações
        public void Validar()
        {
            Validacoes.ValidarSeMenorQue(Hora, 0, "Hora não pode ser menor que zero.");
            Validacoes.ValidarMinimoMaximo(Minuto, 0, 59, "Minuto deve ser entre 0 e 59.");
            
        }
        #endregion

    }
}
