using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LmsDDD.Core.DomainObjects
{
    public class Validacoes
    {
        public static void ValidarSeIgual(object object1, object object2, string mensagem)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeIgual(int valor1, int valor2, string mensagem)
        {
            if (valor1 == valor2)
            {
                throw new DomainException(mensagem);
            }
        }


        public static void ValidarSeDiferente(object object1, object object2, string mensagem)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeDiferente(string pattern, string valor, string mensagem)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(valor))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarTamanho(string valor, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarTamanho(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeNulo(object object1, string mensagem)
        {
            if (object1 == null)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeMenorQue(long valor, long minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeMenorQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }


        public static void ValidarSeMenorIgualQue(long valor, long minimo, string mensagem)
        {
            if (valor <= minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeMenorIgualQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor <= minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeMenorQue(double valor, double minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeMenorQue(int valor, int minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeFalso(bool boolvalor, string mensagem)
        {
            if (!boolvalor)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarSeVerdadeiro(bool boolvalor, string mensagem)
        {
            if (boolvalor)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void ValidarUrl(string url, string mensagem)
        {

            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!reg.IsMatch(url))
                throw new DomainException(mensagem);
        }


        public static void ValidarQuantidadeMinimaNumeros(string valor, int tamanhoMinimo, string mensagem)
        {
            throw new ArgumentException(mensagem);

        }

        public static void ValidarQuantidadeMinimaLetrasMaiusculas(string valor, int tamanhoMinimo, string mensagem)
        {
            throw new ArgumentException(mensagem);

        }

        public static void ValidarQuantidadeMinimaCaracteresEspeciais(string valor, int tamanhoMinimo, string mensagem)
        {
            throw new ArgumentException(mensagem);

        }

    }
}
