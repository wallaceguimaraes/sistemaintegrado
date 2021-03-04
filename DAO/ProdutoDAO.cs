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
    class ProdutoDAO
    {

        public int ValidaCodigo(string codigo)
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from produto p where p.codigo='" + codigo + "'";
            DataSet Mysqldset = new DataSet();
            try
            {
                conexao.Open();
                comando = new MySqlCommand(comando.CommandText, conexao);
                MySqlDataAdapter Mysqldap = new MySqlDataAdapter(comando);
                Mysqldap.Fill(Mysqldset);
                if (Mysqldset.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }
                return 1;
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


        public int ValidaNomeImagem(string nome)
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from produto p where p.nome_imagem='" + nome + "'";
            DataSet Mysqldset = new DataSet();
            try
            {
                conexao.Open();
                comando = new MySqlCommand(comando.CommandText, conexao);
                MySqlDataAdapter Mysqldap = new MySqlDataAdapter(comando);
                Mysqldap.Fill(Mysqldset);
                if (Mysqldset.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }
                return 1;
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

        public int IncluirProduto(Produto produto)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();
            Mysqlcom.CommandText = "insert into produto (nome,codigo,descricao,imagem,valor_custo,preco_venda,tipo_produto_id,nome_imagem,fornecedor_id)"
                + "values (?nome,?codigo,?descricao,?imagem,?valor_custo,?preco_venda,?tipo_produto_id,?nomeImg,?fornecedor_id)";
            Mysqlcom.Parameters.AddWithValue("?nome", produto.GetNome());
            Mysqlcom.Parameters.AddWithValue("?codigo", produto.GetCodigo());
            Mysqlcom.Parameters.AddWithValue("?descricao", produto.GetDescricao());
            Mysqlcom.Parameters.AddWithValue("?imagem", produto.GetImagem());
            Mysqlcom.Parameters.AddWithValue("?valor_custo", produto.GetValorCusto());
            Mysqlcom.Parameters.AddWithValue("?preco_venda", produto.GetPrecoVenda());
            Mysqlcom.Parameters.AddWithValue("?tipo_produto_id", produto.GetTipoProduto());
            Mysqlcom.Parameters.AddWithValue("?nomeImg", produto.GetNomeImagem());

            Mysqlcom.Parameters.AddWithValue("?fornecedor_id", produto.GetFornecedor_id());

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


        public DataTable ListarProduto()
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select p.produto_id as id, p.codigo as CODIGO, p.nome as PRODUTO," +
                "p.descricao as DESCRICAO,tp.tipo_prod_id, tp.descricao as CATEGORIA, p.valor_custo as VALOR_CUSTO, p.preco_venda as PRECO_VENDA, " +
                "f.fornecedor_id as fornecedorId,f.nome as FORNECEDOR,p.imagem, p.ativo as ATIVO, p.nome_imagem from produto p" +
                " inner join tipo_produto tp on p.tipo_produto_id=tp.tipo_prod_id " +
                " inner join fornecedor f on p.fornecedor_id = f.fornecedor_id where p.ativo='SIM' order by p.nome";
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

        public DataTable ListarProdutoPorFornec(int Id)
        {
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select p.produto_id as id, p.codigo as CODIGO, p.nome as PRODUTO," +
                "p.descricao as DESCRICAO,tp.tipo_prod_id, tp.descricao as CATEGORIA, p.valor_custo as VALOR_CUSTO, p.preco_venda as PRECO_VENDA, " +
                "f.fornecedor_id,f.nome as FORNECEDOR,p.imagem, p.ativo as ATIVO, p.nome_imagem from produto p" +
                " inner join tipo_produto tp on p.tipo_produto_id=tp.tipo_prod_id " +
                " inner join fornecedor f on p.fornecedor_id = f.fornecedor_id where p.ativo='SIM' and p.fornecedor_id="+Id+" order by p.nome";
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






        public DataTable PesquisarProduto(Produto produto)
        {
            string busca = "";
            Conection conecta = new Conection();
            MySqlConnection conexao = new MySqlConnection(conecta.connection);
            MySqlCommand comando = conexao.CreateCommand();
            ArrayList filtro = new ArrayList();

            if (string.IsNullOrWhiteSpace(produto.GetNomeImagem())) { produto.SetNomeImagem(""); }

            if (produto.GetAtivo() == "") { produto.SetAtivo("SIM"); }
            if (!produto.GetCodigo().Equals("")) { filtro.Add("p.codigo like '%" + produto.GetCodigo() + "%'"); }
            if (!produto.GetDescricao().Equals("")) { filtro.Add("p.descricao like '%" + produto.GetDescricao() + "%'"); }
            if (!produto.GetNome().Equals("")) { filtro.Add("p.nome like '%" + produto.GetNome() + "%'"); }
            if (!produto.GetNomeImagem().Equals("")) { filtro.Add("p.nome_imagem like '%" + produto.GetNomeImagem() + "%'"); }


            if (produto.GetValorCusto()!=0) { filtro.Add("p.valor_custo  <= " + produto.GetValorCusto() + ""); }
            if (produto.GetPrecoVenda()!=0) { filtro.Add("p.preco_venda <= " + produto.GetPrecoVenda() + ""); }


             filtro.Add("p.ativo='" + produto.GetAtivo() + "'");

            if (filtro.Count > 0)
            {
                busca = "WHERE " + String.Join(" AND ", filtro.ToArray());
            }
            else
            {
                busca = "";
            }

            comando.CommandText = "select p.produto_id as id, p.codigo as CODIGO, p.nome as PRODUTO," +
                "p.descricao as DESCRICAO,tp.tipo_prod_id, tp.descricao as CATEGORIA, p.valor_custo as VALOR_CUSTO, p.preco_venda as PRECO_VENDA, " +
                "f.fornecedor_id,f.nome as FORNECEDOR,p.imagem, p.ativo as ATIVO, p.nome_imagem from produto p" +
                " inner join tipo_produto tp on p.tipo_produto_id=tp.tipo_prod_id " +
                " inner join fornecedor f on p.fornecedor_id = f.fornecedor_id " + busca;

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



        public int AtualizarProduto(Produto produto)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();
          

                Mysqlcom.CommandText = "update produto set nome = ?nome, descricao = ?descricao," +
                " valor_custo = ?valor_custo, preco_venda = ?preco_venda,fornecedor_id=?fornecedor_id,tipo_produto_id=?tipo_produto_id," +
                "imagem=?imagem,nome_imagem=?nome_imagem, ativo = ?ativo where produto_id= ?produto_id";

                Mysqlcom.Parameters.AddWithValue("?nome", produto.GetNome());
                Mysqlcom.Parameters.AddWithValue("?produto_id", produto.GetProduto_id());
                Mysqlcom.Parameters.AddWithValue("?descricao", produto.GetDescricao());
                Mysqlcom.Parameters.AddWithValue("?valor_custo", produto.GetValorCusto());
                Mysqlcom.Parameters.AddWithValue("?preco_venda", produto.GetPrecoVenda());
            Mysqlcom.Parameters.AddWithValue("?fornecedor_id", produto.GetFornecedor_id());
            Mysqlcom.Parameters.AddWithValue("?tipo_produto_id", produto.GetTipoProduto());
            Mysqlcom.Parameters.AddWithValue("?imagem", produto.GetImagem());
            Mysqlcom.Parameters.AddWithValue("?nome_imagem", produto.GetNomeImagem());
            Mysqlcom.Parameters.AddWithValue("?ativo", produto.GetAtivo());

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


        public int ExcluirProduto(int id)
        {
            Conection conecta = new Conection();
            MySqlConnection Mysqlcon = new MySqlConnection(conecta.connection);
            MySqlCommand Mysqlcom = Mysqlcon.CreateCommand();


            Mysqlcom.CommandText = "update produto set ativo = 'NAO' where produto_id= ?produto_id";

            Mysqlcom.Parameters.AddWithValue("?produto_id", id);
          
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
