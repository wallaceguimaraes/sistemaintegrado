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
   public class TipoProdutoController
    {

        TipoProdutoDAO tPDao = new TipoProdutoDAO();

        public DataTable ListarTipoProdutoPorId(int id)
        {
            DataTable dados;
            dados = tPDao.ListarTipoProdutoPorId(id);
            return dados;
        }

        public int IncluirTipoProduto(TipoProduto tipoProduto)
        {
            int flag;
            flag = tPDao.IncluirTipoProduto(tipoProduto);
            return flag;
        }


        public DataTable ListarTipoProduto()
        {
            DataTable dados;
            dados = tPDao.ListarTipoProduto();
            return dados;
        }


        public DataTable PesquisarTipoProduto(TipoProduto tProduto)
        {
            DataTable dados;
            dados = tPDao.PesquisarTipoProduto(tProduto);
            return dados;
        }


        public int AtualizarTipoProduto(TipoProduto tProduto)
        {
            int flag;
            flag = tPDao.AtualizarTipoProduto(tProduto);
            return flag;
        }

        public int ExcluirTipoProduto(int id)
        {
            int flag;
            flag = tPDao.ExcluirTipoProduto(id);
            return flag;
        }

    }
}
