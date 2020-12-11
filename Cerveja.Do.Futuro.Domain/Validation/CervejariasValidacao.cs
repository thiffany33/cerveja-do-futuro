using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Interfaces.Validacao;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cerveja.Do.Futuro.Domain.Validation
{
    public class CervejariasValidacao : ICervejariaValidacao
    {
        private readonly ICervejariaRepository _cervejariaRepository;

        public CervejariasValidacao(ICervejariaRepository cervejariaRepository)
        {
            _cervejariaRepository = cervejariaRepository;
        }

        public List<string> Validade(Cervejarias cervejarias)
        {
            var listaErros = new List<string>();

            if (!ValidarCNPJEmBranco(cervejarias.Cnpj))
            {
                listaErros.Add("CNPJ não pode ficar em Branco!");
            }
            else if (!ValidarCNPJ(cervejarias.Cnpj))
            {
                listaErros.Add("CNPJ Inválido!");
            }
            else if (!ValidarExistenciaCNPJ(cervejarias.Cnpj))
            {
                listaErros.Add("CNPJ já Cadastrado!");
            }

            if (!ValidarObrigatoriedadeTelefone(cervejarias.Telefone))
            {
                listaErros.Add("Telefone não pode ficar em branco!");
            }
            else if (!ValidarTelefone(cervejarias.Telefone))
            {
                listaErros.Add("Telefone Inválido!");
            }


            if (!ValidarRazaoSocial(cervejarias.RazaoSocial))
            {
                listaErros.Add("Razão Social Não pode ficar em Branco!");
            }


            if (!ValidarNomeFantasia(cervejarias.NomeFantasia))
            {
                listaErros.Add("Nome Fantasia Não pode ficar em Branco!");
            }


            if (!ValidarEndereco(cervejarias.Endereco))
            {
                listaErros.Add("Endereço Não pode ficar em Branco!");
            }


            if (!ValidarObrigatoriedadeEmail(cervejarias.Email))
            {
                listaErros.Add("Email não pode ficar em branco!");
            }
            else if (!ValidarFormatoEmail(cervejarias.Email))
            {
                listaErros.Add("Email Inválido!");
            }
            return listaErros;
        }

        private static bool ValidarCNPJ(string cnpj)
        {
            if ((Regex.IsMatch(cnpj, @"\D") == true))
            {
                return false;
            }

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
            {
                return false;
            }

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            resto = (soma % 11);
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }
            resto = (soma % 11);
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }

        private static bool ValidarCNPJEmBranco(string cnpj)
        {
            if (cnpj == null)
            {
                return false;
            }
            return true;
        }

        private bool ValidarExistenciaCNPJ(string cnpj)
        {
            var fornecedor = _cervejariaRepository.ObterCervejariasPorCNPJ(cnpj);
            if (fornecedor == null)
            {
                return true;
            }
            return false;
        }

        private static bool ValidarEndereco(string endereco)
        {
            if (endereco == null)
            {
                return false;
            }
            return true;
        }

        private static bool ValidarNomeFantasia(string nomeFantasia)
        {
            if (nomeFantasia == null)
            {
                return false;
            }
            return true;
        }

        private static bool ValidarRazaoSocial(string razaoSocial)
        {
            if (razaoSocial == null)
            {
                return false;
            }
            return true;
        }

        private static bool ValidarObrigatoriedadeTelefone(string telefone)
        {
            if (telefone == null)
            {
                return false;
            }
            return true;
        }

        private static bool ValidarTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"\(\d{2}\)\s\d{8,9}");
        }

        private static bool ValidarFormatoEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
        }

        private static bool ValidarObrigatoriedadeEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            return true;
        }
    }
}
