using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegrado.Model.Entity
{
    public class Produto
    {

        private int produto_id;
        private int fornecedor_id;
        private string nome;
        private string codigo;
        private string descricao;
        private string imagem;
        private decimal valor_custo;
        private decimal preco_venda;
        private int tipo_produto;
        private string nomeImagem;
        private string ativo;

        public Produto()
        { }

        public Produto(int produto_id, int fornecedor_id, string nome, string codigo, string descricao, string imagem, decimal valor_custo, decimal preco_venda, int tipo_produto,string nomeImagem, string ativo)
        {
            this.produto_id = produto_id;
            this.fornecedor_id = fornecedor_id;
            this.nome = nome;
            this.codigo = codigo;
            this.descricao = descricao;
            this.imagem = imagem;
            this.valor_custo = valor_custo;
            this.preco_venda = preco_venda;
            this.tipo_produto = tipo_produto;
            this.nomeImagem = nomeImagem;
            this.ativo = ativo;
        }



        public void SetProduto_id(int produto_id) { this.produto_id = produto_id; }

        public int GetProduto_id() { return produto_id; }

        public void SetFornecedor_id(int fornecedor_id) { this.fornecedor_id = fornecedor_id; }

        public int GetFornecedor_id() { return fornecedor_id; }

        public void SetNome(string nome) { this.nome = nome; }

        public string GetNome() { return nome.ToUpper(); }

        public void SetCodigo(string codigo) { this.codigo = codigo; }

        public string GetCodigo() { return codigo; }

        public void SetDescricao(string descricao) { this.descricao = descricao; }

        public string GetDescricao() { return descricao.ToUpper(); }

        public void SetImagem(string imagem) { this.imagem = imagem; }

        public string GetImagem() { return imagem; }

        public void SetValorCusto(decimal valor_custo) { this.valor_custo = valor_custo; }

        public decimal GetValorCusto() { return valor_custo; }

        public void SetPrecoVenda(decimal preco_venda) { this.preco_venda = preco_venda; }

        public decimal GetPrecoVenda() { return preco_venda; }

        public void SetTipoProduto(int tipo_produto) { this.tipo_produto = tipo_produto; }

        public int GetTipoProduto() { return tipo_produto; }
    
        public void SetNomeImagem(string nomeImagem) { this.nomeImagem = nomeImagem; }

        public string GetNomeImagem() { return nomeImagem; }

        public void SetAtivo(string ativo) { this.ativo = ativo; }

        public string GetAtivo() { return ativo.ToUpper(); }

    }

}

