using MySql.Data.MySqlClient;
using SistemaIntegrado.Model.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegrado.DAO
{
    public class FornecedorDAO
    {

        public DataTable ListarFornecedor()
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            // Cartao cartao = new Cartao();
            comando.CommandText = "select fornecedor_id as id, nome as FORNECEDOR, cpf_cnpj as CPF_CNPJ, telefone as TELEFONE, email as EMAIL, ativo as ATIVO from fornecedor f where f.ativo='SIM' order by f.nome";
            try
            {
                conexao.Open();
                comando = new MySqlCommand(comando.CommandText, conexao);
                MySqlDataAdapter Mysqldap = new MySqlDataAdapter(comando);
                DataTable dados = new DataTable();
                Mysqldap.Fill(dados);
                return dados;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                conexao.Close();
            }
        }



        public DataTable ListarFornecedorPorId(int id)
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            // Cartao cartao = new Cartao();
            comando.CommandText = "select fornecedor_id as id, nome as FORNECEDOR, cpf_cnpj as CPF_CNPJ, telefone as TELEFONE, email as EMAIL, ativo as ATIVO from fornecedor f where" +
                " f.fornecedor_id="+id+" AND f.ativo='SIM' order by f.nome";
            try
            {
                conexao.Open();
                comando = new MySqlCommand(comando.CommandText, conexao);
                MySqlDataAdapter Mysqldap = new MySqlDataAdapter(comando);
                DataTable dados = new DataTable();
                Mysqldap.Fill(dados);
                return dados;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                conexao.Close();
            }
        }






        public DataTable PesquisarFornecedor(Fornecedor fornecedor)
        {
            string busca = "";
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            ArrayList filtro = new ArrayList();

            if (fornecedor.GetAtivo() == "") { fornecedor.SetAtivo("SIM"); }
            if (!fornecedor.GetNome().Equals("")) { filtro.Add("f.nome like '%" + fornecedor.GetNome() + "%'"); }
            filtro.Add("f.ativo='" + fornecedor.GetAtivo() + "'");

            if (filtro.Count > 0)
            {
                busca = "WHERE " + String.Join(" AND ", filtro.ToArray());
            }
            else
            {
                busca = "";
            }

            comando.CommandText = "select fornecedor_id as id, nome as FORNECEDOR, cpf_cnpj as CPF_CNPJ, telefone as TELEFONE, email as EMAIL, ativo as ATIVO from fornecedor f " + busca;

            try
            {
                conexao.Open();
                comando = new MySqlCommand(comando.CommandText, conexao);
                MySqlDataAdapter Mysqldap = new MySqlDataAdapter(comando);
                DataTable dados = new DataTable();
                Mysqldap.Fill(dados);
                return dados;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                conexao.Close();
            }
        }



    }
}
