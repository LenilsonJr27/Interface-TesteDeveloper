using InterfaceTestDev.Models;
using System;
using System.Collections.Generic;

namespace TesteDeveloper
{
    
    public class GerenciadorEstoque
    {
 
        private readonly IList<EstoqueProduto> _estoques;

        public GerenciadorEstoque(IList<EstoqueProduto> estoques)
        {
            _estoques = estoques ?? throw new ArgumentNullException(nameof(estoques));
        }

        
        public bool EstoqueDisponivel(string referencia, int quantidadeRequerida)
        {
            foreach (var produto in _estoques)
            {
                if (produto.Referencia == referencia)
                {
                    return produto.SaldoEstoque >= quantidadeRequerida;
                }
            }
            return false;
            }

        public int GetSaldo(string referencia)
        {
            foreach (var produto in _estoques)
            {
                if (produto.Referencia == referencia)
                {
                    return produto.SaldoEstoque;
                }
            }
            return 0;
        }


        
        public override string ToString()
        {
            var res = new List<string>();
            foreach (var produto in _estoques)
            {
                res.Add($"referência : {produto.Referencia} saldo : {produto.SaldoEstoque}");
            }
            return string.Join("\n", res);
        }


    }

    public class EstoqueService
    {
        private readonly List<EstoqueProduto> _produtos;

        public EstoqueService()
        {
            _produtos = new List<EstoqueProduto>();
        }

        public List<EstoqueProduto> Listar()
        {
            return _produtos;
        }

        public EstoqueProduto BuscarPorId(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }

        public void Adicionar(EstoqueProduto produto)
        {
            produto.Id = _produtos.Any()
                ? _produtos.Max(x => x.Id) + 1
                : 1;

            _produtos.Add(produto);
        }

        public void Atualizar(EstoqueProduto produto)
        {
            var existente = BuscarPorId(produto.Id);

            if (existente == null)
                return;

            existente.Referencia = produto.Referencia;
            existente.SaldoEstoque = produto.SaldoEstoque;
        }

        public void Remover(int id)
        {
            var produto = BuscarPorId(id);

            if (produto != null)
                _produtos.Remove(produto);
        }
    }


}
