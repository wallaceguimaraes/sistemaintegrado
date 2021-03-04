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

namespace SistemaIntegrado.Util
{
    public partial class Informa : Form
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



        public Informa()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

        }


        public DialogResult Resultado { get; private set; }

        public static DialogResult Mostrar(string mensagem, string textoOk)
        {
            var msgBox = new Informa();
            msgBox.lblMensagem.Text = mensagem;
            msgBox.btnOk.Text = textoOk;
            msgBox.ShowDialog();
            return msgBox.Resultado;
        }

      

        private void btnNao_Click(object sender, EventArgs e)
        {
         //   Resultado = DialogResult.No;
            Close();
        }


        private void Mensagem_Load(object sender, EventArgs e)
        {
        }
    }
}
