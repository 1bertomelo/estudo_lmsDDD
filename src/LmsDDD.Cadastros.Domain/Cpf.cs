using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Cadastros.Domain
{
    public class Cpf
    {
        #region Propriedades
        public string Valor { get; private set; }

        #endregion
        #region Construtores
        public Cpf(string valor)
        {
			Validar();
		}
        #endregion

        #region Métodos e sobrecargas       
        public string CpfMascaraFormatada()
        {   
            return $"{Valor.Substring(0, 3) + '.' + Valor.Substring(3, 3) + '.' + Valor.Substring(6, 3) + '-' + Valor.Substring(9, 2)}";
        }
        public override string ToString()
        {
            return CpfMascaraFormatada();
        }

        #endregion

        #region Validações
        public void Validar()
        {
			Validacoes.ValidarSeVazio(Valor, "O campo Valor do CPF não pode estar vazio!");
			Validacoes.ValidarTamanho(Valor, 11, 11, "O campo Valor do CPF não pode estar vazio!");
			if (!ValidarCpfReceita(Valor))
				throw new ArgumentException("Cpf Inválido");
		}

        private bool ValidarCpfReceita(string cpf)
        {			 
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}
        #endregion

    }
}
