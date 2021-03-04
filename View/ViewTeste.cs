using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIntegrado.View
{
    public partial class ViewTeste : Form
    {


        Graphics gra;
        Brush bru = new SolidBrush(Color.Black);
        Color[] cor = new Color[100];


        public ViewTeste()
        {
            InitializeComponent();
            gra = this.CreateGraphics();

        }

        private void gradientPanelMuda2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void botaoAdd_Click(object sender, EventArgs e)
        {

        }

        private void botaoGerar_Click(object sender, EventArgs e)
        {
           
        }

        private void botaoLimpar_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
