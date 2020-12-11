using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Interfaces.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cerveja.Do.Futuro.Aplication.Services
{
    public class ProdutosService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutosValidacao _produtosValidacao;

        public ProdutosService(IProdutoRepository produtoRepository, IProdutosValidacao produtoValidacao)
        {
            _produtoRepository = produtoRepository;
            _produtosValidacao = produtoValidacao;
        }

        public List<string> Cadastrar(Produtos produto)
        {
            var erros = _produtosValidacao.ValidarCadastro(produto);
            if (!erros.Any())
            {
                _produtoRepository.Create(produto);
            }
            return erros;
        }

        public List<string> Deletare(Guid id)
        {
            var erros = _produtosValidacao.ValidarDeletar(id);
            if (!erros.Any())
            {
                _produtoRepository.Delete(id);
            }
            return erros;
        }

        public List<string> Atualizar(Produtos produto)
        {
            var erros = _produtosValidacao.ValidarAtualizar(produto);
            if (!erros.Any())
            {
                _produtoRepository.Update(produto);
            }
            return erros;
        }

        public IEnumerable<Produtos> ListarTodos()
        {
            return _produtoRepository.GetAll();
        }

        public Produtos PesquisarPorId(Guid id)
        {
            return _produtoRepository.GetById(id);
        }
    }
}
