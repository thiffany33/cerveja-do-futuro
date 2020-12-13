using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Interfaces.Validacao;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cerveja.Do.Futuro.Domain.Validation
{
    public class UsuarioValidacao : IUsuarioValidacao
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioValidacao(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<string> ValidarCadastro(Usuario usuario)
        {
            var listaErros = new List<string>();

            if (!ValidarCPFEmBranco(usuario.Cpf))
            {
                listaErros.Add("CPF não pode ficar em Branco!");
            }
            else if (!ValidarCPF(usuario.Cpf))
            {
                listaErros.Add("CPF Inválido!");
            }

            if (!ValidarObrigatoriedadeTelefone(usuario.Telefone))
            {
                listaErros.Add("Telefone não pode ficar em branco!");
            }
            else if (!ValidarTelefone(usuario.Telefone))
            {
                listaErros.Add("Telefone Inválido!");
            }

            if (!ValidarNome(usuario.Nome))
            {
                listaErros.Add("Nome Não pode ficar em Branco!");
            }

            if (!ValidarEndereco(usuario.Endereco))
            {
                listaErros.Add("Endereço Não pode ficar em Branco!");
            }

            if (!ValidarObrigatoriedadeEmail(usuario.Email))
            {
                listaErros.Add("Email não pode ficar em branco!");
            }
            else if (!ValidarFormatoEmail(usuario.Email))
            {
                listaErros.Add("Email Inválido!");
            }

            if (!ValidarObrigatoriedadeSenha(usuario.Senha))
            {
                listaErros.Add("Senha não pode ficar em branco!");
            }
            //else if (!ValidarFormatoSenha(usuario.Senha))
            //{
            //    listaErros.Add("Senha Inválida");
            //}

            return listaErros;
        }

        public List<string> ValidarDeletar(Guid id)
        {
            var listaErros = new List<string>();
            if (_usuarioRepository.GetById(id) == null)
            {
                listaErros.Add("Id Invalido");
            }
            return listaErros;
        }

        public List<string> ValidarEditar(Usuario usuario)
        {
            var listaErros = ValidarCadastro(usuario);
            if(_usuarioRepository.GetById(usuario.Id) == null)
            {
                listaErros.Add("Id não encontrador");
            }
            return listaErros;
        }

        private static bool ValidarObrigatoriedadeSenha(string senha)
        {
            if (senha == null)
            {
                return false;
            }
            return true;
        }

        //private static bool ValidarFormatoSenha(string senha)
        //{
        //    return Regex.IsMatch(senha, @"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/");
        //}

        private static bool ValidarCPF(string cpf)
        {
            if ((Regex.IsMatch(cpf, @"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/") == true))
            {
                return false;
            }
            return true;
        }

        private static bool ValidarCPFEmBranco(string cpf)
        {
            if (cpf == null)
            {
                return false;
            }
            return true;
        }

        private static bool ValidarEndereco(string endereco)
        {
            if (endereco == null)
            {
                return false;
            }
            return true;
        }

        private static bool ValidarNome(string nome)
        {
            if (nome == null)
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
