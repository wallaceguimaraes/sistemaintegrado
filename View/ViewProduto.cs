using SistemaIntegrado.Controller;
using SistemaIntegrado.Model.Entity;
using SistemaIntegrado.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace SistemaIntegrado.View
{
    public partial class ViewProduto : Form
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

        public ViewProduto(int flag)
        {

            Flag = flag;
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            fotostring = "";
            AplicarEventos(textBoxValor);
            AplicarEventos(textBoxPreco);
           // AplicarEventos(textBoxQtd);
            nomeFoto = "";
            tProduto = 0;
            tFornecedor = 0;
            produto.SetTipoProduto(0);
            produto.SetFornecedor_id(0);
            imagemByte = null;
            edicao = "";

            if (Flag == 1)
            {
                //Ver apenas Tela de cadastro dos produtos
                ListarTipoProduto();
                ListarFornecedor();
                gPMCategoria.Visible = false;
               
               
            }
            else if (Flag == 2)
            {
                //Ver apenas a tela de listagem de produtos
                ListarProduto();
                gPMProduto.Visible = true;
                gPMCategoria.Visible = false;

                buttonProduto.BackColor = System.Drawing.Color.SteelBlue;
                buttonCadastro.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);



            }

        }

        Produto produto = new Produto();
        TipoProduto tipoProduto = new TipoProduto();
        //Fornecedor fornecedor = new Fornecedor();
        string fotostring;
        byte[] imagemByte;
        string nomeFoto;
        Image Imagem;
        int tProduto;
        int tFornecedor;
        string edicao;


        private void ListarTipoProduto()
        {
            TipoProdutoController tPController = new TipoProdutoController();


            if (gPMCategoria.Visible == true)
            {
                tabelaCCategoria.DataSource = tPController.ListarTipoProduto();
                tabelaCCategoria.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
                //tabelaTipo.Column
                tabelaCCategoria.Columns[0].Visible = false;
            }
            else
            {

                tabelaTipo.DataSource = tPController.ListarTipoProduto();
                tabelaTipo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
                //tabelaTipo.Column
                tabelaTipo.Columns[0].Visible = false;
                tabelaTipo.Columns[2].Visible = false;
            }

        }

        private void ListarFornecedor()
        {
            FornecedorController fController = new FornecedorController();
            tabelaFornec.DataSource = fController.ListarFornecedor();
            tabelaFornec.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            tabelaFornec.Columns[2].HeaderText = "CPF/CNPJ";
            //tabelaTipo.Column
            tabelaFornec.Columns[0].Visible = false;
            //tabelaFornec.Columns[2].Visible = false;
            tabelaFornec.Columns[3].Visible = false;
            tabelaFornec.Columns[4].Visible = false;
            tabelaFornec.Columns[5].Visible = false;


        }

        private void SelecionarLinhaTipoProduto(object sender, EventArgs e)
        {

            if (gPMCategoria.Visible == true)
            {


                if (tabelaCCategoria.SelectedRows.Count > 0)
                {
                    DataRowView dr = (DataRowView)tabelaCCategoria.Rows[tabelaCCategoria.SelectedRows[0].Index].DataBoundItem;

                    
                        tipoProduto.SetTipoProdutoId(Convert.ToInt32(dr["id"]));
                        textBoxCDesc.Text = dr["CATEGORIA"].ToString();
                    comboBoxCAtivo.Text = dr["ATIVO"].ToString();
                    botaoCSalvar.Enabled = false;
                    botaoCPesq.Enabled = false;
                    botaoCExcluir.Enabled = true;
                    botaoCAtualizar.Enabled = true;

                    return;
                   

                }

            }
            else
            {
                if (tabelaTipo.SelectedRows.Count > 0)
                {
                    DataRowView dr = (DataRowView)tabelaTipo.Rows[tabelaTipo.SelectedRows[0].Index].DataBoundItem;

                    DialogResult resultado = Mensagem.Mostrar("   Você deseja escolher esse                    tipo de produto?", "Sim", "Não");//19 a 26 espaços
                    if (resultado.ToString() == "Yes")
                    {
                        produto.SetTipoProduto(Convert.ToInt32(dr["id"]));
                        //                    MessageBox.Show(produto.GetTipoProduto().ToString());
                        return;
                    }
                    else
                    {

                    }
                }


            }



        }

        private void SelecionarLinhaProduto(object sender, EventArgs e)
        {            
            if (tabelaProduto.SelectedRows.Count > 0)
            {
                DataRowView dr = (DataRowView)tabelaProduto.Rows[tabelaProduto.SelectedRows[0].Index].DataBoundItem;
                produto.SetProduto_id(Convert.ToInt32(dr["id"]));
               // produto.SetQtdMinima(Convert.ToInt32(dr["qtd_minima"])); 
                textBoxCodigoP.Text = dr["codigo"].ToString();
                textBoxCodigoP.TextAlign = HorizontalAlignment.Right;

                textBoxProdutoP.Text = dr["produto"].ToString();
                textBoxProdutoP.TextAlign = HorizontalAlignment.Right;

                textBoxDescP.Text = dr["descricao"].ToString();
                textBoxDescP.TextAlign = HorizontalAlignment.Right;


                textBoxValorP.Text = dr["valor_custo"].ToString();
                textBoxValorP.TextAlign = HorizontalAlignment.Right;
                textBoxPrecoP.Text = dr["preco_venda"].ToString();
                textBoxPrecoP.TextAlign = HorizontalAlignment.Right;
                comboBoxAtivoP.Text = dr["ativo"].ToString();
                tProduto = Convert.ToInt32(dr["tipo_prod_id"]);
                tFornecedor = Convert.ToInt32(dr["fornecedor_id"]);

                nomeFoto = dr["nome_imagem"].ToString();
                fotostring = dr["imagem"].ToString();
  
                string caminho =fotostring+""+nomeFoto+".jpg";
             
                pictureBoxP.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxP.Image = Image.FromFile(caminho);

                textBoxCodigoP.ReadOnly = true;
                textBoxProdutoP.ReadOnly = true;
                textBoxDescP.ReadOnly = true;
                textBoxPrecoP.ReadOnly = true;
                textBoxValorP.ReadOnly = true;
                comboBoxAtivoP.Enabled = false;

                botaoCancelar.Enabled = true;
                botaoEditar.Enabled = true;
                botaoPesquisar.Enabled = false;
                botaoExc.Enabled = true;

                BarcodeWriter br = new BarcodeWriter();
                //br.Format = BarcodeFormat.QR_CODE;
                br.Format = BarcodeFormat.CODE_128;

                //Bitmap bm = new Bitmap(br.Write(textBoxCodigo.Text), 100, 100);
                Bitmap bm = new Bitmap(br.Write(textBoxCodigoP.Text), 179, 52);

                pictureBoxCodigo2.Image = bm;


            }
        }


        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private void SelecionarLinhaFornecedor(object sender, EventArgs e)
        {

            if (tabelaFornec.SelectedRows.Count > 0)
            {
                DataRowView dr = (DataRowView)tabelaFornec.Rows[tabelaFornec.SelectedRows[0].Index].DataBoundItem;

                DialogResult resultado = Mensagem.Mostrar("   Você deseja escolher esse                         fornecedor?", "Sim", "Não");//19 a 26 espaços
                if (resultado.ToString() == "Yes")
                {
                    produto.SetFornecedor_id(Convert.ToInt32(dr["id"]));
                    //                    MessageBox.Show(produto.GetTipoProduto().ToString());
                    return;
                }
                else
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void AplicarEventos(TextBox txt)
        {
         
            txt.KeyPress += ApenasValorNumerico;
        }

        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;
            }
        }

        private void botaoCanc_Click(object sender, EventArgs e)
        {

//            DialogResult resultado = Mensagem.Mostrar("Você deseja escolher esse tipo de produto?", "Sim", "Não");
//            MessageBox.Show("Ola"+resultado.ToString());

        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

         
        }

        private void button_captura_Click(object sender, EventArgs e)
        {       
            ViewCam cam = new ViewCam();
            cam.ShowDialog();
            if (cam.Valor == "1")
            {
                //Não faz nada
            }
            else
            {
                imagemByte = System.Text.Encoding.Default.GetBytes(cam.Valor);
                pictureBox1.Image = ByteArrayToImage(imagemByte);
                fotostring = SalvarImagem();


                //BarcodeReader br = new BarcodeReader();
                //string texto = br.Decode((Bitmap)pictureBox1.Image).ToString();
                //textBoxDesc.Text = texto;
                //textBoxDesc.Text = texto;

                if (!string.IsNullOrWhiteSpace(cam.Barras))
                {
                    textBoxCodigo.Text = cam.Barras;
                    botaoGerar.Enabled = false;

                    BarcodeWriter br = new BarcodeWriter();
                    //br.Format = BarcodeFormat.QR_CODE;
                    br.Format = BarcodeFormat.CODE_128;

                    //Bitmap bm = new Bitmap(br.Write(textBoxCodigo.Text), 100, 100);
                    Bitmap bm = new Bitmap(br.Write(textBoxCodigo.Text), 179, 52);

                    pictureBoxCodigo.Image = bm;
                }
            }
        }


        public Image ByteArrayImage(byte[] img) { return Image.FromStream(new MemoryStream(img)); }

        public Image ByteToImage(byte[] image)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(image);
        }

        private void botaoGerar_Click(object sender, EventArgs e)
        {
        
            string codigo="";

            while (codigo == "")
            {

                string caracteresPermitidos = "0123456789";
                int TamanhoDaSenha = 13;
                char[] chars = new char[TamanhoDaSenha];
                Random rd = new Random();
                for (int i = 0; i < TamanhoDaSenha; i++)
                {
                    chars[i] = caracteresPermitidos[rd.Next(0, caracteresPermitidos.Length)];
                }

                codigo = new string(chars);
                ProdutoController pControl = new ProdutoController();
                int resp= pControl.ValidaCodigo(codigo);

                if (resp == 0)
                {
                    textBoxCodigo.Text = codigo;


                    BarcodeWriter br = new BarcodeWriter();
                    //br.Format = BarcodeFormat.QR_CODE;
                    br.Format = BarcodeFormat.CODE_128;

                    //Bitmap bm = new Bitmap(br.Write(textBoxCodigo.Text), 100, 100);
                    Bitmap bm = new Bitmap(br.Write(textBoxCodigo.Text), 179, 52);

                    pictureBoxCodigo.Image = bm;
                    


                }
                else
                {
                    codigo = "";
                }

            }

            





        }

        //Botoes Menu Lateral
        private void buttonProduto_Click(object sender, EventArgs e)
        {
            ListarProduto();
            gPMProduto.Visible = true;
            buttonProduto.BackColor = System.Drawing.Color.SteelBlue;
            buttonCadastro.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
        }

        //
        private void SelecionarImagem(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Selecionar Fotos";
            openFileDialog1.InitialDirectory = @"C:\Users";
            //filtra para exibir somente arquivos de imagens
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Le os arquivos selecionados 
                foreach (String arquivo in openFileDialog1.FileNames)
                {
                    textBox1.Text += arquivo;
                    // cria um PictureBox
                    try
                    {
                        Imagem = Image.FromFile(arquivo);
                     
                        pictureBox1.Image = Imagem;

                        fotostring = SalvarImagem();

                        pictureBoxP.Image = Imagem;
                        pictureBoxP.SizeMode = PictureBoxSizeMode.StretchImage;

                        produto.SetNomeImagem(arquivo.Substring(45, 10));


                    }
                    catch (SecurityException ex)
                    {
                        // O usuário  não possui permissão para ler arquivos
                        MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                                    "Mensagem : " + ex.Message + "\n\n" +
                                                    "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        // Não pode carregar a imagem (problemas de permissão)
                        MessageBox.Show("Não é possível exibir a imagem: " + ex.Message);
                    }
                }
            }
        }

        private string SalvarImagem()
        {
            nomeFoto = "";

            while (nomeFoto == "")
            {

                string caracteresPermitidos = "WALLACEGUIMARAESSILVAS0123456789";
                int TamanhoDaSenha = 20;
                char[] chars = new char[TamanhoDaSenha];
                Random rd = new Random();
                for (int i = 0; i < TamanhoDaSenha; i++)
                {
                    chars[i] = caracteresPermitidos[rd.Next(0, caracteresPermitidos.Length)];
                }

                nomeFoto = new string(chars);

                //Verificar se ja existe esse nome na base

                ProdutoController pController = new ProdutoController();
                int resp =  pController.ValidaNomeImagem(nomeFoto);
                if(resp == 1)
                {
                    nomeFoto = "";
                }
               



            }
            string path = "C:\\SistemaIntegrado\\SistemaIntegrado\\Imagens\\";
            pictureBox1.Image.Save(path+""+nomeFoto+".jpg", ImageFormat.Jpeg);
            return path;

        }
    
        private void buttonCadastro_Click(object sender, EventArgs e)
        {
            ViewCadastro cadastro = new ViewCadastro();
            cadastro.Show();
            this.Hide();
        }

        private void botao1_Cancelar(object sender, EventArgs e)
        {

            textBoxProdutoP.Text = "";
            textBoxDescP.Text = "";
            textBoxCodigoP.Text = "";
            fotostring = "";
            pictureBoxP.Image = null;
            textBoxValorP.Text = "";
            textBoxPrecoP.Text = "";
            produto.SetProduto_id(0);
            comboBoxAtivoP.Text = "";
            botaoCancelar.Enabled = false;
            textBoxCodigoP.ReadOnly = false;
            textBoxProdutoP.ReadOnly = false;
            textBoxDescP.ReadOnly = false;
            textBoxPrecoP.ReadOnly = false;
            textBoxValorP.ReadOnly = false;
            comboBoxAtivoP.Enabled = true;
            botaoPesquisar.Enabled = true;




        }
        
        private void ListarFornecedorPorId(int id)
        {
            FornecedorController fController = new FornecedorController();
            tabelaFornec.DataSource = fController.ListarFornecedorPorId(id);
            tabelaFornec.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            tabelaFornec.Columns[2].HeaderText = "CPF/CNPJ";
            tabelaFornec.Columns[0].Visible = false;
            tabelaFornec.Columns[3].Visible = false;
            tabelaFornec.Columns[4].Visible = false;
            tabelaFornec.Columns[5].Visible = false;
        }

        private void PesquisarTipoProduto(TipoProduto tProduto)
        {

            if (gPMCategoria.Visible == true)
            {
                TipoProdutoController tPController = new TipoProdutoController();
                tabelaCCategoria.DataSource = tPController.PesquisarTipoProduto(tProduto);
                tabelaCCategoria.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
                //tabelaTipo.Column
                tabelaCCategoria.Columns[0].Visible = false;
            }
            else
            {

                TipoProdutoController tPController = new TipoProdutoController();
                tabelaTipo.DataSource = tPController.PesquisarTipoProduto(tProduto);
                tabelaTipo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
                //tabelaTipo.Column
                tabelaTipo.Columns[0].Visible = false;
                tabelaTipo.Columns[2].Visible = false;
            }
            }
        private void PesquisarFornecedor(Fornecedor fornecedor)
        {
            FornecedorController fController = new FornecedorController();
            tabelaFornec.DataSource = fController.PesquisarFornecedor(fornecedor);
            tabelaFornec.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            //tabelaTipo.Column
            tabelaTipo.Columns[0].Visible = false;
            tabelaTipo.Columns[2].Visible = false;
        }


        private void botaoPTipo_Click(object sender, EventArgs e)
        {
            TipoProduto tipoProduto = new TipoProduto();
            tipoProduto.SetDescricao(textBoxPTipo.Text);
            tipoProduto.SetAtivo("");

            PesquisarTipoProduto(tipoProduto);


        }



        //CRUD


        private void botaoPesquisar_Click(object sender, EventArgs e)
        {


            produto.SetCodigo(textBoxCodigoP.Text);
            produto.SetAtivo(comboBoxAtivoP.Text);
            produto.SetNome(textBoxProdutoP.Text);
            produto.SetDescricao(textBoxDescP.Text);
            

            if (string.IsNullOrWhiteSpace(textBoxValorP.Text) || textBoxValorP.Text.Equals(""))
            {
                produto.SetValorCusto(0);
            }
            else
            {
                produto.SetValorCusto(Convert.ToDecimal(textBoxValorP.Text));

            }
            if (string.IsNullOrWhiteSpace(textBoxPrecoP.Text) || textBoxPrecoP.Text.Equals(""))
            {
                produto.SetPrecoVenda(0);

            }
            else
            {
                produto.SetPrecoVenda(Convert.ToDecimal(textBoxPrecoP.Text));

            }




            pesquisarProduto(produto);

          

        }

        private void botaoGravar_Click(object sender, EventArgs e)
        {
            ProdutoController pController = new ProdutoController();
            tProduto = produto.GetTipoProduto();
            tFornecedor = produto.GetFornecedor_id();

            if (string.IsNullOrWhiteSpace(textBoxCodigo.Text) || string.IsNullOrWhiteSpace(textBoxProduto.Text) || tProduto == 0 || tFornecedor == 0)
            {


                Informa.Mostrar("Existem campos obrigatórios que  não foram preenchidos!", "Ok");

            }
            else
            {
                produto.SetCodigo(textBoxCodigo.Text);
                produto.SetNome(textBoxProduto.Text);
                produto.SetDescricao(textBoxDesc.Text);
               // fotostring = SalvarImagem();
                produto.SetImagem(fotostring);
                produto.SetNomeImagem(nomeFoto);

                if (string.IsNullOrWhiteSpace(textBoxValor.Text))
                {
                    produto.SetValorCusto(0);
                }
                else
                {
                    produto.SetValorCusto(Convert.ToDecimal(textBoxValor.Text));

                }
                if (string.IsNullOrWhiteSpace(textBoxPreco.Text))
                {
                    produto.SetPrecoVenda(0);
                }
                else
                {
                    produto.SetPrecoVenda(Convert.ToDecimal(textBoxPreco.Text));

                }

                //produto.SetQtdMinima(Convert.ToInt32(textBoxQtd.Text));

                int flag;
                flag = pController.IncluirProduto(produto);
                if (flag == 1)
                {
                    Informa.Mostrar("    O produto foi salvo com                              sucesso!", "Ok");
                    textBoxProduto.Text = "";
                    textBoxDesc.Text = "";
                    textBoxCodigo.Text = "";
                    fotostring = "";
                    nomeFoto = "";
                    pictureBox1.Image = null;
                    pictureBoxP.Image = null;
                    textBoxValor.Text = "";
                    textBoxPreco.Text = "";
                    // textBoxQtd.Text = "";
                    ListarProduto();
                  //  produto = null;


                }
                else
                {
                    Informa.Mostrar("Ocorreu um erro ao salvar!", "Ok");

                }
            }

        }
        private void ListarProduto()
        {
            ProdutoController pController = new ProdutoController();
            tabelaProduto.DataSource = pController.ListarProduto();
            tabelaProduto.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            tabelaProduto.ColumnHeadersDefaultCellStyle.Alignment = new DataGridViewContentAlignment();

            //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            //tabelaTipo.Column

            tabelaProduto.Columns[6].DefaultCellStyle.Format = "c";
            tabelaProduto.Columns[7].DefaultCellStyle.Format = "c";

            tabelaProduto.Columns[6].HeaderText = "VALOR CUSTO";
            tabelaProduto.Columns[7].HeaderText = "PRECO VENDA";

            tabelaProduto.Columns[0].Visible = false;
            tabelaProduto.Columns[4].Visible = false;
            tabelaProduto.Columns[8].Visible = false;
            tabelaProduto.Columns[10].Visible = false;
            tabelaProduto.Columns[11].Visible = false;
            tabelaProduto.Columns[12].Visible = false;

        }
        private void ListarTipoProdutoPorId(int id)
        {
            TipoProdutoController tPController = new TipoProdutoController();
            tabelaTipo.DataSource = tPController.ListarTipoProdutoPorId(id);
            tabelaTipo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            //tabelaTipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            //tabelaTipo.Column
            tabelaTipo.Columns[0].Visible = false;
            tabelaTipo.Columns[2].Visible = false;

        }
        private void botaoEditar_Click(object sender, EventArgs e)
        {

            buttonMenuCliente.Visible = false;
            buttonMenCargo.Visible = false;
            buttonMenEmp.Visible = false;
            buttonMenFornec.Visible = false;
            buttonMenFunc.Visible = false;
            // buttonMenuProduto.Visible = false;
            buttonMenUsu.Visible = false;
            botaoGerar.Visible = false;
            buttonMenuProduto.Location = new System.Drawing.Point(9, 0);

            gPMProduto.Visible = false;
            textBoxCodigo.Text = textBoxCodigoP.Text;
            textBoxCodigo.TextAlign = HorizontalAlignment.Right;
            textBoxProduto.Text = textBoxProdutoP.Text;
            textBoxProduto.TextAlign = HorizontalAlignment.Right;

            textBoxDesc.Text = textBoxDescP.Text;
            textBoxDesc.TextAlign = HorizontalAlignment.Right;

            textBoxValor.Text = textBoxValorP.Text;
            textBoxValor.TextAlign = HorizontalAlignment.Right;

            textBoxPreco.Text = textBoxPrecoP.Text;
            textBoxPreco.TextAlign = HorizontalAlignment.Right;

            pictureBox1.Image = pictureBoxP.Image;
            pictureBoxCodigo.Image = pictureBoxCodigo2.Image;

            comboBoxAtivo.Text = comboBoxAtivoP.Text;

            ListarTipoProdutoPorId(tProduto);
            ListarFornecedorPorId(tFornecedor);

            botaoEditar.Enabled = false;
            botaoAtualizar.Visible = true;
            comboBoxAtivo.Visible = true;
            labelAtivo.Visible = true;

            textBoxCodigoP.Text = "";
            textBoxProdutoP.Text = "";
            textBoxDescP.Text = "";
            textBoxValorP.Text = "";
            textBoxPrecoP.Text = "";
            comboBoxAtivoP.Text = "";
            pictureBoxP.Image = null;
            botaoPesquisar.Enabled = true;
            comboBoxAtivoP.Enabled = true;

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
            tabelaProduto.Columns[7].HeaderText = "PRECO VENDA";

            tabelaProduto.Columns[0].Visible = false;
            tabelaProduto.Columns[4].Visible = false;
            tabelaProduto.Columns[8].Visible = false;
            tabelaProduto.Columns[10].Visible = false;
            tabelaProduto.Columns[11].Visible = false;
            tabelaProduto.Columns[12].Visible = false;

        }

        private void botaoPFor_Click(object sender, EventArgs e)
        {

            Fornecedor fornecedor = new Fornecedor();
            fornecedor.SetNome(textBoxPFor.Text);
            fornecedor.SetAtivo("");
            PesquisarFornecedor(fornecedor);

        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {

            ProdutoController pController = new ProdutoController();
            tProduto = produto.GetTipoProduto();
            tFornecedor = produto.GetFornecedor_id();

            if ( string.IsNullOrWhiteSpace(textBoxProduto.Text) || tProduto == 0 || tFornecedor == 0)
            {


                Informa.Mostrar("Existem campos obrigatórios que não foram preenchidos!", "Ok");

            }
            else
            {
                produto.SetCodigo(textBoxCodigo.Text);
                produto.SetNome(textBoxProduto.Text);
                produto.SetDescricao(textBoxDesc.Text);


        
                produto.SetImagem(fotostring);
                produto.SetNomeImagem(nomeFoto);
                produto.SetAtivo(comboBoxAtivo.Text);
                

                if (string.IsNullOrWhiteSpace(textBoxValor.Text))
                {
                    produto.SetValorCusto(0);    
                }
                else
                {
                    produto.SetValorCusto(Convert.ToDecimal(textBoxValor.Text));

                }

                if (string.IsNullOrWhiteSpace(textBoxPreco.Text))
                {
                    produto.SetPrecoVenda(0);
                }
                else
                {
                    produto.SetPrecoVenda(Convert.ToDecimal(textBoxPreco.Text));

                }
                

                int flag;
                flag = pController.AtualizarProduto(produto);
                if (flag == 1)
                {
                    Informa.Mostrar("     Produto atualizado com                              sucesso!", "Ok");
                    textBoxProduto.Text = "";
                    textBoxDesc.Text = "";
                    textBoxCodigo.Text = "";
                    fotostring = "";
                    pictureBox1.Image = null;
                    nomeFoto = "";
                    textBoxValor.Text = "";
                    textBoxPreco.Text = "";
                    // textBoxQtd.Text = "";
                    comboBoxAtivo.Text = "";
                   // produto = null;


                }
                else
                {
                    Informa.Mostrar("Ocorreu um erro ao atualizar!", "Ok");

                }
            }





        }

        private void botao1_Click(object sender, EventArgs e)
        {
            tipoProduto.SetDescricao(textBoxPTipo.Text);
            tipoProduto.SetAtivo(comboBoxCAtivo.Text);
            
            PesquisarTipoProduto(tipoProduto);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            gPMCategoria.Visible = true;
            ListarTipoProduto();


        }



        //CATEGORIA

        private void button5_Click(object sender, EventArgs e)
        {
            gPMCategoria.Visible = false;
            ListarProduto();
        }

        private void botaoCSalvar_Click(object sender, EventArgs e)
        {
            TipoProdutoController tPController = new TipoProdutoController();
     

            if (string.IsNullOrWhiteSpace(textBoxCDesc.Text))
            {


                Informa.Mostrar("Existem campos obrigatórios que  não foram preenchidos!", "Ok");

            }
            else
            {
                
                tipoProduto.SetDescricao(textBoxCDesc.Text);
                
             
            
                int flag;
                flag = tPController.IncluirTipoProduto(tipoProduto);
                if (flag == 1)
                {
                    Informa.Mostrar("    A categoria foi salva com                              sucesso!", "Ok");
                    textBoxCDesc.Text = "";
                    comboBoxCAtivo.Text = "";

                    ListarTipoProduto();


                }
                else
                {
                    Informa.Mostrar("Ocorreu um erro ao salvar!", "Ok");

                }
            }
        }

        private void botaoCCancelar_Click(object sender, EventArgs e)
        {
            botaoCSalvar.Enabled = true;
            textBoxCDesc.Text = "";
            comboBoxCAtivo.Text = "";
        }

        private void botaoCExcluir_Click(object sender, EventArgs e)
        {
            TipoProdutoController tPController = new TipoProdutoController();

            int flag = tPController.ExcluirTipoProduto(tipoProduto.GetTipoProdutoId());
            if(flag == 1)
            {
                Informa.Mostrar("     Registro excluido com                                 sucesso!", "Ok");
                ListarTipoProduto();
                textBoxCDesc.Text = "";
                comboBoxCAtivo.Text = "";
                tipoProduto.SetTipoProdutoId(0);
                botaoCExcluir.Enabled = false;
                botaoCAtualizar.Enabled = false;
                botaoCSalvar.Enabled = true;
                botaoCPesq.Enabled = true;
                botaoCPesq.Enabled = true;

            }
            else
            {
                Informa.Mostrar("Ocorreu um erro ao tentar excluir!!", "Ok");

            }

        }

        private void botaoExc_Click(object sender, EventArgs e)
        {
            ProdutoController produtoController = new ProdutoController();
            int resp;
            resp=produtoController.ExcluirProduto(produto.GetProduto_id());
            if(resp == 1)
            {
                Informa.Mostrar("       O registro foi excluido                       com sucesso!", "Ok");
                botaoExc.Enabled = false;
                botaoEditar.Enabled = false;
                botaoGravar.Enabled = true;
                botaoPesquisar.Enabled = true;
                ListarProduto();
                textBoxCodigoP.Text = "";
                textBoxProdutoP.Text = "";
                textBoxDescP.Text = "";
                textBoxValorP.Text = "";
                textBoxPrecoP.Text = "";
                comboBoxAtivoP.Text = "";
                comboBoxAtivoP.Enabled = true;
                pictureBoxP.Image = null;
            }
            else
            {
                Informa.Mostrar("         Ocorreu um erro ao tentar                        excluir!", "Ok");

            }

        }

        private void botaoCAtualizar_Click(object sender, EventArgs e)
        {

            TipoProdutoController tPController = new TipoProdutoController();

            if (string.IsNullOrWhiteSpace(textBoxCDesc.Text))
            {
                Informa.Mostrar("Por favor preencha o campo 'Descricao'.", "Ok");

                return;
            }

            tipoProduto.SetAtivo(comboBoxCAtivo.Text);
            tipoProduto.SetDescricao(textBoxCDesc.Text);

           int flag = tPController.AtualizarTipoProduto(tipoProduto);

            if (flag == 1)
            {
                Informa.Mostrar("     Registro atualizado com                             sucesso!", "Ok");
                ListarTipoProduto();
                textBoxCDesc.Text="";
                comboBoxCAtivo.Text = "";
                tipoProduto.SetTipoProdutoId(0);
                botaoCExcluir.Enabled = false;
                botaoCAtualizar.Enabled = false;
                botaoCSalvar.Enabled = true;
                botaoCPesq.Enabled = true;
                botaoCPesq.Enabled = true;

            }
            else
            {
                Informa.Mostrar("Ocorreu um erro ao tentar atualizar!", "Ok");
            }


        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void buttonPedidos_Click(object sender, EventArgs e)
        {
            ViewPedido vPedido = new ViewPedido(1);
            vPedido.Show();
            this.Hide();
        }
    }
}
