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
    public class TipoProdutoDAO
    {
        public DataTable ListarTipoProduto()
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
           // Cartao cartao = new Cartao();
            comando.CommandText = "select tipo_prod_id as id, descricao as CATEGORIA, ativo as ATIVO from tipo_produto tp where tp.ativo='SIM' order by tp.descricao";
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



        public DataTable ListarTipoProdutoPorId(int id)
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            // Cartao cartao = new Cartao();
            comando.CommandText = "select tipo_prod_id as id, descricao as CATEGORIA, ativo as ATIVO from tipo_produto tp" +
                " where tp.tipo_prod_id="+id+" AND tp.ativo='SIM' order by tp.descricao";
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


        public DataTable PesquisarTipoProduto(TipoProduto tProduto)
        {
            string busca = "";
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            ArrayList filtro = new ArrayList();

            if (tProduto.GetAtivo() == "") { tProduto.SetAtivo("SIM"); }
            if (!tProduto.GetDescricao().Equals("")) { filtro.Add("tp.descricao like '%" + tProduto.GetDescricao() + "%'"); }
            filtro.Add("tp.ativo='" + tProduto.GetAtivo() + "'");

            if (filtro.Count > 0)
            {
                busca = "WHERE " + String.Join(" AND ", filtro.ToArray());
            }
            else
            {
                busca = "";
            }

            comando.CommandText = "select tipo_prod_id as id, descricao as CATEGORIA, ativo as Ativo from tipo_produto tp " + busca;

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

        public int IncluirTipoProduto(TipoProduto tProduto)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();
            Mysqlcom.CommandText = "insert into tipo_produto (descricao)"
                + "values (?descricao)";
          
            Mysqlcom.Parameters.AddWithValue("?descricao", tProduto.GetDescricao());
           

            try
            {
                Mysqlcon.Open();
                Mysqlcom.ExecuteNonQuery();
                return 1;
            }
            catch (MySqlException e)
            {
                throw new ApplicationException(e.ToString());
            }
            finally
            {
                Mysqlcon.Close();
            }
        }






        public int AtualizarTipoProduto(TipoProduto tproduto)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();


            Mysqlcom.CommandText = "update tipo_produto set descricao = ?descricao, ativo = ?ativo where tipo_prod_id= ?tipo_prod_id";

            Mysqlcom.Parameters.AddWithValue("?tipo_prod_id", tproduto.GetTipoProdutoId());
            Mysqlcom.Parameters.AddWithValue("?descricao", tproduto.GetDescricao());          
            Mysqlcom.Parameters.AddWithValue("?ativo", tproduto.GetAtivo());

            try
            {
                Mysqlcon.Open();
                Mysqlcom.ExecuteNonQuery();
                return 1;
            }
            catch (MySqlException e)
            {
                throw new ApplicationException(e.ToString());
            }
            finally
            {
                Mysqlcon.Close();
            }
        }

        public int ExcluirTipoProduto(int id)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();


            Mysqlcom.CommandText = "update tipo_produto set ativo = 'NÃO' where tipo_prod_id= ?id";
            Mysqlcom.Parameters.AddWithValue("?id", id);

            try
            {
                Mysqlcon.Open();
                Mysqlcom.ExecuteNonQuery();
                return 1;
            }
            catch (MySqlException e)
            {
                throw new ApplicationException(e.ToString());
            }
            finally
            {
                Mysqlcon.Close();
            }
        }



    }
}
