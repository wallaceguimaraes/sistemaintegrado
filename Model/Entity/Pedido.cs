using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegrado.Model.Entity
{
    public class Pedido
    {
        private int pedidoId;
        private decimal valor;
        private decimal frete;
        private string status;
        private int clienteId;
        private int vendedorId;
        private string ativo;
        private string prazoEntrega;
        private string dataHora;


        public Pedido()
        {


        }
        public Pedido(int pedidoId, decimal valor, decimal frete, string status, int clienteId, int vendedorId, string ativo, string prazoEntrega, string dataHora)
        {
            this.pedidoId = pedidoId;
            this.valor = valor;
            this.frete = frete;
            this.status = status;
            this.ativo = ativo;
            this.clienteId = clienteId;
            this.vendedorId = vendedorId;
            this.dataHora = dataHora;
            this.prazoEntrega = prazoEntrega;
        }


        public void SetPedidoId(int pedidoId) { this.pedidoId = pedidoId; }
        public int GetPedidoId() { return pedidoId; }

        public void SetValor(decimal valor) { this.valor = valor; }
        public decimal GetValor() { return valor; }

        public void SetFrete(decimal frete) { this.frete = frete; }
        public decimal GetFrete() { return frete; }

        public void SetStatus(string status) { this.status = status; }
        public string GetStatus() { return status; }


        public void SetClienteId(int clienteId) { this.clienteId = clienteId; }
        public int GetClienteId() { return clienteId; }

        public void SetVendedorId(int vendedorId) { this.vendedorId = vendedorId; }
        public int GetVedendorId() { return vendedorId; }

        public void SetPrazoEntrega(string prazoEntrega) { this.prazoEntrega = prazoEntrega; }
        public string GetPrazoEntrega() { return prazoEntrega; }

        public void SetDataHora(string dataHora) { this.dataHora = dataHora; }
        public string GetDataHora() { return dataHora; }
            
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
