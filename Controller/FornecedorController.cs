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
   public class FornecedorController
    {



        FornecedorDAO fDao = new FornecedorDAO();

        public DataTable ListarFornecedor()
        {
            DataTable dados;
            dados = fDao.ListarFornecedor();
            return dados;
        }

        public DataTable ListarFornecedorPorId(int id)
        {
            DataTable dados;
            dados = fDao.ListarFornecedorPorId(id);
            return dados;
        }



        public DataTable PesquisarFornecedor(Fornecedor fornecedor)
        {

            DataTable dados;
            dados = fDao.PesquisarFornecedor(fornecedor);
            return dados;
        }
    }
}
