using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Interfaces.Validacao;
using System;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Domain.Validation
{
    public class ProdutosValidacao : IProdutosValidacao
    {
        private readonly ICervejariaRepository _cervejariaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosValidacao(ICervejariaRepository cervejariaRepository, IProdutoRepository produtoRepository)
        {
            _cervejariaRepository = cervejariaRepository;
            _produtoRepository = produtoRepository;
        }

        public List<string> ValidarCadastro(Produtos produto)
        {
            var listaErros = new List<string>();

            if (!ValidarNome(produto.Nome))
            {
                listaErros.Add("Nome não pode ficar em Branco!");
            }

            if (!ValidarPreco(produto.Preco))
            {
                listaErros.Add("Preco não pode ser menor que zero");
            }

            if (!ValidarValidade(produto.Validade))
            {
                listaErros.Add("A data tem que ser maior que a data atual");
            }

            if (!ValidarCervejaria(produto.CervejariasId))
            {
                listaErros.Add("Essa categoria não existe");
            }

            return listaErros;
        }

        public List<string> ValidarDeletar(Guid id)
        {
            var listaErros = new List<string>();
            if (_produtoRepository.GetById(id) == null)
            {
                listaErros.Add("Id Inválido!");
            }
            return listaErros;
        }

        public List<string> ValidarAtualizar(Produtos produto)
        {
            var listaErros = ValidarCadastro(produto);
            if (_produtoRepository.GetById(produto.Id) == null)
            {
                listaErros.Add("Id não Encontrado!");
            }
            return listaErros;
        }

        private bool ValidarNome(string nome) => !string.IsNullOrWhiteSpace(nome);

        private bool ValidarPreco(double preco) => preco > 0;

        private bool ValidarValidade(DateTime validade) => (validade > DateTime.Now.Date);

        private bool ValidarCervejaria(Guid id) => _cervejariaRepository.GetById(id) != null;
    }
}
