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
    public class ProdutoController
    {
        ProdutoDAO pDao = new ProdutoDAO();

        public int IncluirProduto(Produto produto)
        {
            int flag;

            flag = pDao.IncluirProduto(produto);
        
            return flag;
        }

        public DataTable ListarProduto()
        {
            DataTable dados;
            dados = pDao.ListarProduto();
            return dados;
        }

        public DataTable ListarProdutoPorFornec(int Id)
        {
            DataTable dados;
            dados = pDao.ListarProdutoPorFornec(Id);
            return dados;
        }


        public int ValidaCodigo( string codigo)
        {
            int resp;
            resp=pDao.ValidaCodigo(codigo);
            return resp;
        }

        public int ValidaNomeImagem(string nome)
        {
            int resp;
            resp = pDao.ValidaNomeImagem(nome);
            return resp;
        }


        public int AtualizarProduto(Produto produto)
        {
            int resp;
            resp = pDao.AtualizarProduto(produto);
            return resp;
        }
        public int ExcluirProduto(int id)
        {
            int resp;
            resp = pDao.ExcluirProduto(id);
            return resp;
        }
        public DataTable PesquisarProduto(Produto produto)
        {
            DataTable dados;
            dados = pDao.PesquisarProduto(produto);
            return dados;
        }


    }
}
