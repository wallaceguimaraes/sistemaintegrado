using AcessoControle.Model.Entity;
using SistemaIntegrado.Controller;
using SistemaIntegrado.Model.Entity;
using SistemaIntegrado.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIntegrado.View
{
    public partial class ViewPedido : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
   int nLeftRect,     // x-coordinate of upper-left corner
   int nTopRect,      // y-coordinate of upper-left corner
   int nRightRect,    // x-coordinate of lower-right corner
   int nBottomRect,   // y-coordinate of lower-right corner
   int nWidthEllipse, // height of ellipse
   int nHeightEllipse // width of ellipse
);


        int Flag;

        public ViewPedido(int flag)
        {

            Flag = flag;
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));





            if (Flag == 1)
            {
                //Ver apenas Tela de cadastro pedidos



                //ListarProduto();
                ListarFornecedorCombo();

            }

            else if (Flag == 2)
            {
                //Ver apenas a tela
                

            }


        }


        Produto produto = new Produto();
        Pedido pedido = new Pedido();

        string qtd;
        string subtotal;
        decimal valorTotal = 0;
        int fornecedorId;
        decimal frete;
        string nomeFoto;
        string fotostring;
        string fornec;

        private void ListarProdutoPorFornec(int id)
        {
            ProdutoController pController = new ProdutoController();
            tabelaProduto.DataSource = pController.ListarProdutoPorFornec(id);
            tabelaProduto.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            tabelaProduto.ColumnHeadersDefaultCellStyle.Alignment = new DataGridViewContentAlignment();
            //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            //tabelaTipo.Column
            tabelaProduto.Columns[6].HeaderText = "VALOR CUSTO";
            tabelaProduto.Columns[6].DefaultCellStyle.Format = "c";
            

            tabelaProduto.Columns[0].Visible = false;
            tabelaProduto.Columns[1].Visible = false;
            tabelaProduto.Columns[4].Visible = false;
            tabelaProduto.Columns[7].Visible = false;
            tabelaProduto.Columns[8].Visible = false;
            tabelaProduto.Columns[9].Visible = false;
            tabelaProduto.Columns[10].Visible = false;
            tabelaProduto.Columns[11].Visible = false;
            tabelaProduto.Columns[12].Visible = false;

        }

        private void ListarPedidos()
        {
            PedidoController pController = new PedidoController();
            tabelaFPedidos.DataSource = pController.ListarPedido();
            tabelaFPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            tabelaFPedidos.ColumnHeadersDefaultCellStyle.Alignment = new DataGridViewContentAlignment();
            tabelaFPedidos.Columns["VALOR"].DefaultCellStyle.Format = "c";

            //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            //tabelaTipo.Column
            tabelaFPedidos.Columns[3].HeaderText = "DATA/HORA";

            tabelaFPedidos.Columns[0].Visible = false;
            tabelaFPedidos.Columns[5].Visible = false;


        }

        private void ListarFornecedorCombo()
        {
            FornecedorController fController = new FornecedorController();
            comboBoxPFornec.DataSource = fController.ListarFornecedor();
            comboBoxFFornec.DataSource = fController.ListarFornecedor();

            comboBoxPFornec.ValueMember = "id";
            comboBoxPFornec.DisplayMember = "FORNECEDOR";
            comboBoxFFornec.ValueMember = "id";
            comboBoxFFornec.DisplayMember = "FORNECEDOR";





        }


        private void SelecionarLinhaProduto(object sender, EventArgs e)
        {
            if (tabelaProduto.SelectedRows.Count > 0)
            {
                DataRowView dr = (DataRowView)tabelaProduto.Rows[tabelaProduto.SelectedRows[0].Index].DataBoundItem;
                produto.SetProduto_id(Convert.ToInt32(dr["id"]));
                produto.SetNome(dr["produto"].ToString());

                produto.SetFornecedor_id(Convert.ToInt32(dr["fornecedor_id"].ToString()));

                produto.SetValorCusto(Convert.ToDecimal(dr["valor_custo"].ToString()));

                nomeFoto = dr["nome_imagem"].ToString();
                fotostring = dr["imagem"].ToString();

                string caminho = fotostring + "" + nomeFoto + ".jpg";

                pictureBoxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxImagem.Image = Image.FromFile(caminho);


            }
        }



        private void SelecionarLinhaItens(object sender, EventArgs e)
        {
            if (tabelaItens.SelectedRows.Count > 0)
            {
                DataRowView dr = (DataRowView)tabelaItens.Rows[tabelaItens.SelectedRows[0].Index].DataBoundItem;


                
               nomeFoto =tabelaItens.CurrentRow.Cells["Column6"].Value.ToString();
               
                fotostring = tabelaItens.CurrentRow.Cells["Column7"].Value.ToString();

                string caminho = fotostring + "" + nomeFoto + ".jpg";

                pictureBoxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxImagem.Image = Image.FromFile(caminho);
                botaoExcluir.Enabled = true;



            }
        }


        private void gradientPanelMudaCad_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void botaoBuscar_Click(object sender, EventArgs e)
        {



            produto.SetNome(textBoxPProduto.Text);            
                produto.SetValorCusto(0);        
                produto.SetPrecoVenda(0);
            produto.SetAtivo("SIM");
            produto.SetCodigo("");
            produto.SetNomeImagem("");
            produto.SetDescricao("");


            pesquisarProduto(produto);
        }




        private void pesquisarProduto(Produto produto)
        {
            ProdutoController pController = new ProdutoController();
            tabelaProduto.DataSource = pController.PesquisarProduto(produto);
            tabelaProduto.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            tabelaProduto.ColumnHeadersDefaultCellStyle.Alignment = new DataGridViewContentAlignment();
            //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            //tabelaTipo.Column
            tabelaProduto.Columns[6].HeaderText = "VALOR CUSTO";

            tabelaProduto.Columns[0].Visible = false;
            tabelaProduto.Columns[1].Visible = false;
            tabelaProduto.Columns[4].Visible = false;
            tabelaProduto.Columns[7].Visible = false;
            tabelaProduto.Columns[8].Visible = false;
            tabelaProduto.Columns[9].Visible = false;
            tabelaProduto.Columns[10].Visible = false;
            tabelaProduto.Columns[11].Visible = false;
            tabelaProduto.Columns[12].Visible = false;

        }



        private void botaoAdicionar_Click(object sender, EventArgs e)
        {
            if(tabelaProduto.SelectedRows.Count == 0)
            {
                Informa.Mostrar("Por favor selecione o produto!", "Ok");
                return;
            }


            if (string.IsNullOrWhiteSpace(textBoxQtd.Text))
            {
                Informa.Mostrar("Por favor preencha o campo de quantidade do produto!", "Ok");
                return;
            }


            if (produto.GetFornecedor_id() != fornecedorId)
            {
                Informa.Mostrar("Os produtos escolhidos devem ser do mesmo fornecedor!", "Ok");

                return;
            }


            qtd = textBoxQtd.Text;

            int quant = Convert.ToInt32(qtd);
            decimal custo = produto.GetValorCusto();

            valorTotal = valorTotal + quant * custo;
            labelTotal.Text = valorTotal.ToString();
            subtotal = (quant * custo).ToString();


            // cria as colunas




            // cria uma linha
            DataGridViewRow item = new DataGridViewRow();
                item.CreateCells(tabelaItens);
                // seta os valores
                item.Cells[0].Value = produto.GetNome();
                item.Cells[1].Value = produto.GetValorCusto();
                item.Cells[2].Value = qtd;
                item.Cells[3].Value = subtotal;
                item.Cells[4].Value = produto.GetProduto_id();
                item.Cells[5].Value = nomeFoto;
                item.Cells[6].Value = fotostring;



            // adiciona na grid

            tabelaItens.Rows.Add(item);
            tabelaItens.Columns[1].DefaultCellStyle.Format = "c";
            tabelaItens.Columns[3].DefaultCellStyle.Format = "c";
            /*
            for (int i = 0; i < 9; i++)
            {
            }
            */
            if (tabelaItens.Rows.Count > 0)
            {
                botaoProcessar.Enabled = true;
                botaoExcluir.Enabled = true;
                botaoAtualizarPedido.Enabled = true;
            }

        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {



            decimal sub = Convert.ToDecimal(tabelaItens.CurrentRow.Cells["Column4"].Value.ToString());
            labelTotal.Text =(valorTotal = valorTotal - sub).ToString();
            int linha = tabelaItens.CurrentCell.RowIndex;
            tabelaItens.Rows.RemoveAt(linha);
            tabelaItemAux.Rows.RemoveAt(linha);

            pictureBoxImagem.Image = null;

            botaoAtualizarPedido.Enabled = true;

            if (tabelaItens.Rows.Count == 0)
            {
                botaoProcessar.Enabled = false;
                botaoExcluir.Enabled = false;
            }


        }

        private void botaoProcessar_Click(object sender, EventArgs e)
        {

            Pedido pedido = new Pedido();
            ItemPedido iPedido = new ItemPedido();
            int flag = 0;

            Usuario usu = new Usuario();
            usu = Sessao.getInstance().getUsuario();
            pedido.SetClienteId(usu.GetUsuario_id());
            pedido.SetFrete(Convert.ToDecimal(textBoxFrete.Text));
            valorTotal = valorTotal + pedido.GetFrete();
            pedido.SetValor(valorTotal);
            pedido.SetVendedorId(fornecedorId);

            int idPedido = incluirPedido(pedido);

            if (idPedido == 0)
            {
                Informa.Mostrar("Ocorreu um erro ao tentar realizar o pedido!", "Ok");
                return;
            }

                for (int i = 0; i < tabelaItens.Rows.Count; i++)
            {
                string coluna1 = tabelaItens.Rows[i].Cells[0].Value.ToString();// coluna 1
                string coluna2 = tabelaItens.Rows[i].Cells[1].Value.ToString();// coluna 2
                string coluna3 = tabelaItens.Rows[i].Cells[2].Value.ToString();// coluna 3
                string coluna4 = tabelaItens.Rows[i].Cells[3].Value.ToString();// coluna 3
                string coluna5 = tabelaItens.Rows[i].Cells[4].Value.ToString();// coluna 3
               // Informa.Mostrar(coluna1+" "+coluna2+" "+coluna3+" "+" "+coluna4+" "+coluna5, "Ok"
                    iPedido.SetPedidoId(idPedido);

                    iPedido.SetProdutoId(Convert.ToInt32(coluna5));
                    iPedido.SetValorUnit(Convert.ToDecimal(coluna2));
                    iPedido.SetQtd(Convert.ToInt32(coluna3));
                    iPedido.SetSubTotal(Convert.ToDecimal(coluna4));

                    flag=incluirItensPedido(iPedido);

                                  
            }

            if (flag == 1)
            {
                Informa.Mostrar("Seu pedido foi relizado com sucesso!", "Ok");
                tabelaItens.Rows.Clear();
                pictureBoxImagem.Image = null;
                textBoxQtd.Text = "";
                valorTotal = 0;
                labelTotal.Text = "0";
                pedido.SetFrete(0);
                textBoxFrete.Text = "0";
            }
            else
            {
                Informa.Mostrar("Ocorreu algum erro ao tentar realizar o pedido!", "Ok");

            }





        }


        private int incluirPedido(Pedido pedido)
        {
            PedidoController pController = new PedidoController();
            
            int id = pController.IncluirPedido(pedido);
            return id;
        }

        private int incluirItensPedido(ItemPedido itemPedido)
        {
            ItemPedidoController iPController = new ItemPedidoController();
            int flag = iPController.IncluirItensPedido(itemPedido);
            return flag;
        }


        private void NaoDigita(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void SelecionaFornecedor(object sender, EventArgs e)
        {
            tabelaItens.Rows.Clear();
            botaoProcessar.Enabled = false;
            labelTotal.Text = "0";
            valorTotal = 0;
            //subtotal = 0;

            int id = Convert.ToInt32(comboBoxPFornec.SelectedValue);
            pedido.SetVendedorId(Convert.ToInt32(comboBoxFFornec.SelectedValue));

            fornecedorId = id;

            ListarProdutoPorFornec(id);

            if(tabelaProduto.Rows.Count > 0)
            {
                botaoAdicionar.Enabled = true;
                botaoBuscar.Enabled = true;

            }
            else
            {
                botaoAdicionar.Enabled = false;
                botaoBuscar.Enabled = false;
            }
            // this.dataGridView.Rows.Clear();



        }

        private void painelRedondo3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gradientPanelMuda4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonMenLista_Click(object sender, EventArgs e)
        {
            //gradientPanelMudaPedido.Visible = false;
            gradientPanelMudFin.Visible = true;
            maskedTextBoxData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ListarPedidos();
            tabelaItens.Rows.Clear();
            //ListarFornecedorCombo();
            valorTotal = 0;
            labelTotal.Text = "0";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            gradientPanelMudFin.Visible = false;
            botaoExcluir.Enabled = false;
            botaoBuscar.Enabled = false;
            botaoAdicionar.Enabled = false;
            botaoAtualizarPedido.Enabled = false;
            comboBoxPFornec.Enabled = true;

        }

        private void botaoFBuscar_Click(object sender, EventArgs e)
        {
            Pedido pedid = new Pedido();

            if (maskedTextBoxData.MaskCompleted)
            {
                pedid.SetDataHora(maskedTextBoxData.Text);
            }
            else
            {
                pedid.SetDataHora("");
            }

            pedid.SetVendedorId(pedido.GetVedendorId());
            pedid.SetStatus(comboBoxFAtivo.Text);
            pedid.SetAtivo("SIM");
            


           pesquisarPedido(pedid);





        }


        private void pesquisarPedido(Pedido pedido)
        {
            PedidoController pC = new PedidoController();

           tabelaFPedidos.DataSource=pC.PesquisarPedido(pedido);
           tabelaFPedidos.Columns[0].Visible = false;
           
        }



        private void SelecionarLinhaPedido(object sender, EventArgs e)
        {
            if (tabelaFPedidos.SelectedRows.Count > 0)
            {
                DataRowView dr = (DataRowView)tabelaFPedidos.Rows[tabelaFPedidos.SelectedRows[0].Index].DataBoundItem;
                pedido.SetPedidoId(Convert.ToInt32(dr["id"]));
                pedido.SetVendedorId(Convert.ToInt32(dr["vendedor_id"]));
                fornec = dr["FORNECEDOR"].ToString();
                pedido.SetValor(Convert.ToDecimal(dr["VALOR"]));
                pedido.SetFrete(Convert.ToDecimal(dr["FRETE"]));
                botaoFCancelar.Enabled = true;
                botaoFExc.Enabled = true;

            }
        }

        private void botao2_Click(object sender, EventArgs e)
        {


            gradientPanelMudFin.Visible = false;



            ItemPedidoController ipC = new ItemPedidoController();
            ProdutoController pCon = new ProdutoController();

            tabelaItemAux.DataSource =ipC.ListarItemPorPedido(pedido.GetPedidoId());

            ListarProdutoPorFornec(pedido.GetVedendorId());

            fornecedorId = pedido.GetVedendorId(); 
            comboBoxPFornec.SelectedValue = pedido.GetVedendorId();
            
            botaoAdicionar.Enabled = true;
            botaoBuscar.Enabled = true;
            botaoProcessar.Visible = false;
            botaoAtualizarPedido.Visible = true;
            valorTotal = Convert.ToDecimal(pedido.GetValor());
            textBoxFrete.Text = pedido.GetFrete().ToString();
            frete = pedido.GetFrete();
            labelTotal.Text = valorTotal.ToString();

            tabelaItemAux.Columns[4].Visible = false;
            tabelaItemAux.Columns[5].Visible = false;
            tabelaItemAux.Columns[6].Visible = false;
            tabelaItemAux.Columns[7].Visible = false;

            comboBoxPFornec.Text = fornec;

            comboBoxPFornec.Enabled = false;




            if (tabelaItemAux.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tabelaItemAux.Rows)
                {
                    object value0 = row.Cells[0].Value;
                    object value1 = row.Cells[1].Value;
                    object value2 = row.Cells[2].Value;
                    object value3 = row.Cells[3].Value;
                    object value4 = row.Cells[4].Value;
                    object value5 = row.Cells[5].Value;
                    object value6 = row.Cells[6].Value;

                    DataGridViewRow item = new DataGridViewRow();
                    item.CreateCells(tabelaItens);
                    // seta os valores
                    item.Cells[0].Value = value0;
                    item.Cells[1].Value = value1;
                    item.Cells[2].Value = value2;
                    item.Cells[3].Value = value3;
                    item.Cells[4].Value = value4;
                    item.Cells[5].Value = value5;
                    item.Cells[6].Value = value6;

                    // adiciona na grid

                    tabelaItens.Rows.Add(item);
                    tabelaItens.Columns[1].DefaultCellStyle.Format = "c";
                    tabelaItens.Columns[3].DefaultCellStyle.Format = "c";

                }
            }

           

            



            
            

           

            



            //gradientPanelMudaPedido










        }

        private void botaoAtualizarPedido_Click(object sender, EventArgs e)
        {

            ItemPedidoController ipc = new ItemPedidoController();
            ItemPedido iPedido = new ItemPedido();
            PedidoController pC = new PedidoController();
            Pedido p = new Pedido();

            ipc.ExcluirItensPedido(pedido.GetPedidoId());
            p.SetPedidoId(pedido.GetPedidoId());
            p.SetValor(valorTotal);

            pC.AtualizarPedido(p);

            int flag = 0;

            for (int i = 0; i < tabelaItens.Rows.Count; i++)
            {
                string coluna1 = tabelaItens.Rows[i].Cells[0].Value.ToString();// coluna 1
                string coluna2 = tabelaItens.Rows[i].Cells[1].Value.ToString();// coluna 2
                string coluna3 = tabelaItens.Rows[i].Cells[2].Value.ToString();// coluna 3
                string coluna4 = tabelaItens.Rows[i].Cells[3].Value.ToString();// coluna 3
                string coluna5 = tabelaItens.Rows[i].Cells[4].Value.ToString();// coluna 3
                iPedido.SetPedidoId(pedido.GetPedidoId());
                iPedido.SetProdutoId(Convert.ToInt32(coluna5));
                iPedido.SetValorUnit(Convert.ToDecimal(coluna2));
                iPedido.SetQtd(Convert.ToInt32(coluna3));
                iPedido.SetSubTotal(Convert.ToDecimal(coluna4));

                flag = incluirItensPedido(iPedido);

            }


            if (flag ==1)
            {
                Informa.Mostrar("O pedido foi atualizado com sucesso!", "Ok");
            }
            else
            {
                Informa.Mostrar("Ocorreu algum erro ao tentar atualizar o pedido!", "Ok");

            }


        }

        private void buttonCadastro_Click(object sender, EventArgs e)
        {

            ViewCadastro vCadastro = new ViewCadastro();
            vCadastro.Show();
            this.Hide();

        }

        private void buttonProduto_Click(object sender, EventArgs e)
        {
            ViewProduto vProduto = new ViewProduto(1);
            vProduto.Show();
            this.Hide();

        }

        private void pegaFrete(object sender, EventArgs e)
        {

            if(Convert.ToDecimal(textBoxFrete.Text) != frete)
            {
                valorTotal = valorTotal - frete;
                valorTotal = valorTotal + Convert.ToDecimal(textBoxFrete.Text);
                labelTotal.Text = valorTotal.ToString();
                frete = Convert.ToDecimal(textBoxFrete.Text);

            }


         
        }
    }
}
