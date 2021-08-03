using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Cadastros.Domain
{
    public class Cnpj
    {
		#region Propriedades
		public string Valor { get; private set; }

		#endregion
		#region Construtores
		public Cnpj(string valor)
		{
			Validar();
		}
		#endregion

		#region Métodos e sobrecargas       
		public string CnpjMascaraFormatada()
		{
			return $"{Valor.Substring(0, 3) + '.' + Valor.Substring(3, 3) + '.' + Valor.Substring(6, 3) + '-' + Valor.Substring(9, 2)}";
		}
		public override string ToString()
		{
			return CnpjMascaraFormatada();
		}

		#endregion

		#region Validações
		public void Validar()
		{
			Validacoes.ValidarSeVazio(Valor, "O campo Valor do Cnpj não pode estar vazio!");
			Validacoes.ValidarTamanho(Valor, 14, 14, "O campo Valor do Cnpj não pode estar vazio!");
			if (!ValidarCnpjReceita(Valor))
				throw new ArgumentException("Cnpj Inválido");
		}

		private bool ValidarCnpjReceita(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}
		#endregion

	}
}
