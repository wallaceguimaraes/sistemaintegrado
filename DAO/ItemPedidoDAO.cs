using MySql.Data.MySqlClient;
using SistemaIntegrado.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegrado.DAO
{
    class ItemPedidoDAO
    {
        public int IncluirItemPedido(ItemPedido itemPedido)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();
            Mysqlcom.CommandText = "insert into item_pedido (produto_id,pedido_id,qtd,valor_unitario,subtotal)"
                + "values (?produto_id,?pedido_id,?qtd,?valor_unitario,?subtotal)";

            Mysqlcom.Parameters.AddWithValue("?produto_id", itemPedido.GetProdutoId());
            Mysqlcom.Parameters.AddWithValue("?pedido_id", itemPedido.GetPedidoId());
            Mysqlcom.Parameters.AddWithValue("?qtd", itemPedido.GetQtd());
            Mysqlcom.Parameters.AddWithValue("?valor_unitario", itemPedido.GetValorUnit());
            Mysqlcom.Parameters.AddWithValue("?subtotal", itemPedido.GetSubTotal());



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



        public DataTable ListarItemPorPedido(int Id)
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select p.nome as PRODUTO, ip.valor_unitario as VALOR, ip.qtd as QUANTIDADE," +
                "ip.subtotal as SUBTOTAL, p.produto_id as PRODUTOID, p.nome_imagem as IMAGEM, p.imagem as CAMINHO, " +
                "ip.item_pedido_id from item_pedido ip" +
                " inner join produto p on ip.produto_id=p.produto_id where ip.ativo='SIM' and ip.pedido_id=" + Id + " order by p.nome asc";
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



        /*
        public int AtualizarItemPedido(ItemPedido itemPedido)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();


            Mysqlcom.CommandText = "update item_pedido set descricao = ?descricao, ativo = ?ativo where tipo_prod_id= ?tipo_prod_id";

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
        */

        public int ExcluirItemPedido(int id)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();


            Mysqlcom.CommandText = "delete from item_pedido where pedido_id="+id+"";

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
