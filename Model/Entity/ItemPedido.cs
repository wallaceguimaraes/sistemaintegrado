using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegrado.Model.Entity
{
    public class ItemPedido
    {
        private int itemPedidoId;
        private int produtoId ;
        private int pedidoId;
        private int qtd;
        private string ativo;
        private decimal valorUnit;
        private decimal subTotal;


        public ItemPedido()
        {


        }
        public ItemPedido(int itemPedidoId, int produtoId, int pedidoId, int qtd, string ativo, decimal valorUnit, decimal subTotal)
        {
            this.itemPedidoId = itemPedidoId;
            this.produtoId = produtoId;
            this.pedidoId = pedidoId;
            this.qtd = qtd;
            this.ativo = ativo;
            this.valorUnit = valorUnit;
            this.subTotal = subTotal;

        }


        public void SetItemPedidoId(int itemPedidoId){ this.itemPedidoId = itemPedidoId; }
        public int GetItemPedidoId(){ return itemPedidoId; }

        public void SetProdutoId(int produtoId){ this.produtoId = produtoId; }
        public int GetProdutoId(){ return produtoId; }
        public void SetPedidoId(int pedidoId) { this.pedidoId = pedidoId; }
        public int GetPedidoId() { return pedidoId; }

        public void SetQtd(int qtd) { this.qtd = qtd; }
        public int GetQtd() { return qtd; }

        public void SetValorUnit(decimal valorUnit) { this.valorUnit = valorUnit; }
        public decimal GetValorUnit() { return valorUnit; }

        public void SetSubTotal(decimal subTotal) { this.subTotal = subTotal; }
        public decimal GetSubTotal() { return subTotal; }

        public void SetAtivo(string ativo)
        {
            this.ativo = ativo;
        }

        public string GetAtivo()
        {
            return ativo;
        }



    }
}
