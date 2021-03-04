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
    class PedidoDAO
    {

        public DataTable ListarPedidos()
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            // Cartao cartao = new Cartao();
            comando.CommandText = "select p.pedido_id as id, f.nome as FORNECEDOR, p.valor as VALOR, p.data_hora as DATA, p.status as SITUACAO, p.vendedor_id, p.frete as FRETE from pedido p " +
                "inner join fornecedor f on p.vendedor_id=f.fornecedor_id where p.ativo='SIM' and p.status!='FINALIZADO' order by p.data_hora,p.status desc";
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






        public int IncluirPedido(Pedido pedido)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();
            Mysqlcom.CommandText = "insert into pedido (valor,frete,cliente_id,vendedor_id)"
                + " values (?valor,?frete,?cliente_id,?vendedor_id)";

            Mysqlcom.Parameters.AddWithValue("?valor", pedido.GetValor());
            Mysqlcom.Parameters.AddWithValue("?frete", pedido.GetFrete());
            Mysqlcom.Parameters.AddWithValue("?cliente_id", pedido.GetClienteId());
            Mysqlcom.Parameters.AddWithValue("?vendedor_id", pedido.GetVedendorId());



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




        public int retornaUltimoID()
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select last_insert_id() as id from dual";
            DataSet Mysqldset = new DataSet();
            try
            {
                conexao.Open();
                comando = new MySqlCommand(comando.CommandText, conexao);
                MySqlDataAdapter Mysqldap = new MySqlDataAdapter(comando);
                Mysqldap.Fill(Mysqldset);

                int id;
                id = (Convert.ToInt32(Mysqldset.Tables[0].Rows[0]["id"]));

                return id;
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






        public DataTable PesquisarPedido(Pedido pedido)
        {
            string busca = "";
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            ArrayList filtro = new ArrayList();

            if (pedido.GetAtivo() == "") { pedido.SetAtivo("SIM"); }
            if (!pedido.GetDataHora().Equals("")) { filtro.Add(" p.data_hora >= str_to_date('" + pedido.GetDataHora() + "','%d/%m/%Y')" ); }
            if (!pedido.GetStatus().Equals("")) { filtro.Add(" p.status ='" + pedido.GetStatus() + "'"); }
            if (!pedido.GetVedendorId().Equals("")) { filtro.Add("p.vendedor_id >=" + pedido.GetVedendorId() + ""); }

            filtro.Add("p.ativo='" + pedido.GetAtivo() + "'");

            if (filtro.Count > 0)
            {
                busca = "WHERE " + String.Join(" AND ", filtro.ToArray());
            }
            else
            {
                busca = "";
            }

            comando.CommandText = "select p.pedido_id as id, f.nome as FORNECEDOR, p.valor as VALOR, p.data_hora as DATA, p.status as SITUACAO, p.vendedor_id, p.frete as FRETE from pedido p " +
                "inner join fornecedor f on p.vendedor_id=f.fornecedor_id " + busca + " and p.status!='FINALIZADO' order by p.data_hora,p.status desc";

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



        public int AtualizarPedido(Pedido pedido)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();


            Mysqlcom.CommandText = "update pedido set valor = ?valor, frete = ?frete, status = 'ANDAMENTO' where pedido_id=?pedido_id";
            Mysqlcom.Parameters.AddWithValue("?valor",pedido.GetValor());
            Mysqlcom.Parameters.AddWithValue("?frete", pedido.GetFrete());
            Mysqlcom.Parameters.AddWithValue("?pedido_id", pedido.GetPedidoId());

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
