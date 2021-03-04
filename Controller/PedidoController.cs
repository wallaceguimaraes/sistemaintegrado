using SistemaIntegrado.DAO;
using SistemaIntegrado.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegrado.Controller
{
    class PedidoController
    {


        PedidoDAO pDao = new PedidoDAO();

        public int IncluirPedido(Pedido pedido)
        {
            int flag=0;
            flag = pDao.IncluirPedido(pedido);

            if (flag == 1)
            {
               flag = pDao.retornaUltimoID();
            }

            return flag;
        }


        public int AtualizarPedido(Pedido pedido)
        {
            int flag;
            flag = pDao.AtualizarPedido(pedido);
            return flag;
        }


        public DataTable ListarPedido()
        {
            DataTable dados;
            dados = pDao.ListarPedidos();
            return dados;
        }



        public DataTable PesquisarPedido(Pedido pedido)
        {
            DataTable dados;
            dados = pDao.PesquisarPedido(pedido);
            return dados;
        }

    }
}
