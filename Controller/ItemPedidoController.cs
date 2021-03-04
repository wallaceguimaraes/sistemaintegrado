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
    class ItemPedidoController
    {


        ItemPedidoDAO IPDao = new ItemPedidoDAO();

        public int IncluirItensPedido(ItemPedido itemPedido)
        {
            int flag;
            flag = IPDao.IncluirItemPedido(itemPedido);
            return flag;
        }

        public int ExcluirItensPedido(int id)
        {
            int flag;
            flag = IPDao.ExcluirItemPedido(id);
            return flag;
        }




        public DataTable ListarItemPorPedido(int Id)
        {
            DataTable dados;
            dados = IPDao.ListarItemPorPedido(Id);
            return dados;
        }

    }
}
