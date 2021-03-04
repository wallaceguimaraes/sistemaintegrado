using AcessoControle.Model.Entity;
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
    public partial class ViewCadastro : Form
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


        public ViewCadastro()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

            Usuario usu = new Usuario();
            usu = Sessao.getInstance().getUsuario();
            if (usu.GetPerfil() == "FUNCIONÁRIO")
            {

                buttonCliente.Visible = false;
                buttonEstoque.Visible = false;
                buttonFinan.Visible = false;
                buttonFuncionario.Visible = false;
                buttonFornecedor.Visible = false;
                buttonPedidoCompra.Visible = false;
                buttonProduto.Visible = false;
                buttonUsuario.Visible = false;
                buttonEmp.Visible = false;
                buttonVenda.Location = new System.Drawing.Point(0, 31);
                buttonServico.Location = new System.Drawing.Point(0, 61);
                buttonMenuProduto.Visible = false;
                buttonMenCargo.Visible = false;
                buttonMenFornec.Visible = false;
                buttonMenEmp.Visible = false;
                buttonMenFunc.Visible = false;
                buttonMenUsu.Visible = false;



            }





        }

        private void buttonMenuProduto_Click(object sender, EventArgs e)
        {
            ViewProduto vProduto = new ViewProduto(1);
            vProduto.Show();
            this.Hide();

        }

        private void buttonProduto_Click(object sender, EventArgs e)
        {
            ViewProduto vProduto = new ViewProduto(2);
            vProduto.Show();
            this.Hide();
        }

        private void buttonEstoque_Click(object sender, EventArgs e)
        {

        }

        private void buttonFinan_Click(object sender, EventArgs e)
        {

        }

        private void buttonVenda_Click(object sender, EventArgs e)
        {

        }

        private void buttonServico_Click(object sender, EventArgs e)
        {

        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {

        }

        private void buttonFuncionario_Click(object sender, EventArgs e)
        {

        }

        private void buttonFornecedor_Click(object sender, EventArgs e)
        {

        }

        private void buttonUsuario_Click(object sender, EventArgs e)
        {

        }

        private void buttonEmp_Click(object sender, EventArgs e)
        {

        }

        private void buttonPedidoCompra_Click(object sender, EventArgs e)
        {

        }

        private void buttonMenFornec_Click(object sender, EventArgs e)
        {
            ViewFornecedor vFornec = new ViewFornecedor(2);
            vFornec.Show();
            this.Hide();



        }

        private void buttonCadastro_Click(object sender, EventArgs e)
        {

        }

        private void buttonPedidos_Click(object sender, EventArgs e)
        {

            ViewPedido vPedido = new ViewPedido(1);
            vPedido.Show();

            this.Hide();

        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
    }
}
